using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    // Apply an effect to a character or body part, depending on whether it's global or local
    public void ApplyEffect(Character character, StatusEffect effect)
    {
        if (effect.isGlobal)
        {
            // Apply the global effect if it's not already active
            if (!character.ActiveGlobalEffects.Contains(effect))
            {
                character.ActiveGlobalEffects.Add(effect);
                effect.ApplyEffect(character);
            }
        }
        else
        {
            // Apply the local effect to a random body part if it's not already active
            BodyPartType bodyPartType = (BodyPartType)Random.Range(0, System.Enum.GetValues(typeof(BodyPartType)).Length);
            BodyPart bodyPart = character.BodyParts[bodyPartType];
            if (!bodyPart.localizedEffects.Contains(effect))
            {
                bodyPart.localizedEffects.Add(effect);
                effect.ApplyEffect(bodyPart);
            }
        }
    }


    // Update the status effects on the character
    public void UpdateStatusEffects(Character character)
    {
        // Update global effects
        for (int i = character.ActiveGlobalEffects.Count - 1; i >= 0; i--)
        {
            var effect = character.ActiveGlobalEffects[i];
            effect.ApplyEffect(character);
            effect.duration -= Time.deltaTime; // Assuming duration is in seconds
            if (effect.duration <= 0)
            {
                effect.RemoveEffect(character);
                character.ActiveGlobalEffects.RemoveAt(i);
            }
        }

        // Update localized effects for each body part
        foreach (var bodyPart in character.BodyParts.Values)
        {
            for (int i = bodyPart.localizedEffects.Count - 1; i >= 0; i--)
            {
                var effect = bodyPart.localizedEffects[i];
                effect.ApplyEffect(bodyPart);
                effect.duration -= Time.deltaTime; // Assuming duration is in seconds
                if (effect.duration <= 0)
                {
                    effect.RemoveEffect(bodyPart);
                    bodyPart.localizedEffects.RemoveAt(i);
                }
            }
        }
    }

}
