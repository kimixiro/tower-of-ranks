// StatusEffectManager.cs

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    // Apply a global effect to a character
    public void ApplyEffect(Character character, StatusEffect effect)
    {
        if (effect.isGlobal)
        {
            ActiveStatusEffect activeEffect = new ActiveStatusEffect(effect, effect.duration);
            var existingEffect = character.ActiveGlobalEffects.FirstOrDefault(ae => ae.effect == effect);
            if (existingEffect != null)
            {
                // Refresh the duration of the existing effect
                existingEffect.remainingDuration = effect.duration;
            }
            else
            {
                character.ActiveGlobalEffects.Add(activeEffect);
                effect.ApplyEffect(character); // Apply the global effect to the character
            }
        }
    }

    // Apply a local effect to a specific body part
    public void ApplyEffect(Character character, StatusEffect effect, BodyPartType bodyPartType)
    {
        if (!effect.isGlobal)
        {
            BodyPart bodyPart = character.BodyParts[bodyPartType];
            ActiveStatusEffect activeEffect = new ActiveStatusEffect(effect, effect.duration);
            var existingEffect = bodyPart.ActiveLocalizedEffects.FirstOrDefault(ae => ae.effect == effect);
            if (existingEffect != null)
            {
                // Refresh the duration of the existing effect
                existingEffect.remainingDuration = effect.duration;
            }
            else
            {
                bodyPart.ActiveLocalizedEffects.Add(activeEffect);
                effect.ApplyEffect(bodyPart); // Apply the local effect to the body part
            }
        }
    }

    // Update the status effects on the character
    public void UpdateStatusEffects(Character character)
    {
        // Update global effects
        foreach (var activeEffect in character.ActiveGlobalEffects.ToList())
        {
            activeEffect.remainingDuration--;
            if (activeEffect.remainingDuration <= 0)
            {
                activeEffect.effect.RemoveEffect(character);
                character.ActiveGlobalEffects.Remove(activeEffect);
            }
            else
            {
                activeEffect.effect.ApplyEffect(character);
            }
        }

        // Update localized effects for each body part
        foreach (var bodyPart in character.BodyParts.Values)
        {
            foreach (var activeEffect in bodyPart.ActiveLocalizedEffects.ToList())
            {
                activeEffect.remainingDuration--;
                if (activeEffect.remainingDuration <= 0)
                {
                    activeEffect.effect.RemoveEffect(bodyPart);
                    bodyPart.ActiveLocalizedEffects.Remove(activeEffect);
                }
                else
                {
                    activeEffect.effect.ApplyEffect(bodyPart);
                }
            }
        }
    }
    
    public bool HasEffect(Character character, StatusEffect effect)
    {
        return character.ActiveGlobalEffects.Any(ae => ae.effect == effect);
    }
}
