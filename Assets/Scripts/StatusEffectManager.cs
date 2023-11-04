using System.Linq;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    // Apply an effect to a character or body part, depending on whether it's global or local
    public void ApplyEffect(Character character, StatusEffect effect)
    {
        ActiveStatusEffect activeEffect = new ActiveStatusEffect(effect, effect.duration);

        if (effect.isGlobal)
        {
            // Check if the character already has this global effect
            if (!character.ActiveGlobalEffects.Any(ae => ae.effect == effect))
            {
                character.ActiveGlobalEffects.Add(activeEffect);
                effect.ApplyEffect(character); // Apply the global effect to the character
            }
        }
        else
        {
            // Apply a local effect to each body part
            foreach (var bodyPart in character.BodyParts.Values)
            {
                // Check if the body part already has this local effect
                if (!bodyPart.ActiveLocalizedEffects.Any(ae => ae.effect == effect))
                {
                    bodyPart.ActiveLocalizedEffects.Add(activeEffect);
                    effect.ApplyEffect(bodyPart); // Apply the local effect to the body part
                }
            }
        }
        
        Debug.Log($"Applied effect: {effect.name} to {character.name}");
    }



    // Update the status effects on the character
    public void UpdateStatusEffects(Character character)
    {
        // Update global effects
        for (int i = character.ActiveGlobalEffects.Count - 1; i >= 0; i--)
        {
            var activeEffect = character.ActiveGlobalEffects[i];
            activeEffect.effect.ApplyEffect(character);
            activeEffect.remainingDuration -= 1; // Decrement the duration by 1 turn

            Debug.Log($"Updated global effect: {activeEffect.effect.name} on {character.name}. Remaining duration: {activeEffect.remainingDuration}");

            if (activeEffect.remainingDuration <= 0)
            {
                activeEffect.effect.RemoveEffect(character);
                character.ActiveGlobalEffects.RemoveAt(i);
                Debug.Log($"Removed global effect: {activeEffect.effect.name} from {character.name}");
            }
        }

        // Update localized effects for each body part
        foreach (var bodyPart in character.BodyParts.Values)
        {
            for (int i = bodyPart.ActiveLocalizedEffects.Count - 1; i >= 0; i--)
            {
                var activeEffect = bodyPart.ActiveLocalizedEffects[i];
                activeEffect.effect.ApplyEffect(bodyPart);
                activeEffect.remainingDuration -= 1; // Decrement the duration by 1 turn

                Debug.Log($"Updated localized effect: {activeEffect.effect.name} on {bodyPart.type} of {character.name}. Remaining duration: {activeEffect.remainingDuration}");

                if (activeEffect.remainingDuration <= 0)
                {
                    activeEffect.effect.RemoveEffect(bodyPart);
                    bodyPart.ActiveLocalizedEffects.RemoveAt(i);
                    Debug.Log($"Removed localized effect: {activeEffect.effect.name} from {bodyPart.type} of {character.name}");
                }
            }
        }
    }
}
