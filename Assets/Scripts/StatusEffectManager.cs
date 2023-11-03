using UnityEngine;

public class StatusEffectManager : MonoBehaviour {

    public void ApplyGlobalEffect(Character character, StatusEffect effect) {
        if (!character.ActiveGlobalEffects.Contains(effect)) {
            character.ActiveGlobalEffects.Add(effect);
            character.InvokeOnGlobalEffectApplied(effect);
            // Modify the effect based on attributes if necessary
            ModifyEffectBasedOnAttributes(character, effect);
        }
    }

    public void ApplyLocalizedEffect(BodyPart bodyPart, StatusEffect effect) {
        bodyPart.ApplyEffect(effect);
        // Handle the application of the localized effect
    }

    public void UpdateStatusEffects(Character character) {
        // Update global effects for the character
        foreach (var effect in character.ActiveGlobalEffects) {
            // Handle the effect progression, such as decrementing duration
        }

        // Update localized effects for each body part
        foreach (var bodyPart in character.BodyParts.Values) {
            foreach (var effect in bodyPart.localizedEffects) {
                // Handle the effect progression
            }
        }
    }

    private void ModifyEffectBasedOnAttributes(Character character, StatusEffect effect) {
        // Adjust the effect based on the character's attributes
        // For example, a high Body attribute might reduce the duration of a poison effect
    }

    // Additional methods for managing status effects
}