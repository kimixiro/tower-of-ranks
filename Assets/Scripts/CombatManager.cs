using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour {
    public Character player;
    public Character enemy;

    private void Start() {
        StartCoroutine(CombatRoutine());
    }

    private IEnumerator CombatRoutine() {
        while (player.TotalHealth > 0 && enemy.TotalHealth > 0) {
            PerformAttack(player, enemy);
            PerformAttack(enemy, player);
            yield return new WaitForSeconds(1f); // Wait 1 second between rounds
        }
    }

    private void PerformAttack(Character attacker, Character defender) {
        // Determine damage
        int damage = Random.Range(10, 20); // Example damage range
        Debug.Log($"{attacker.name} is attacking {defender.name} with {damage} damage.");

        // Choose to attack overall health or a specific body part
        if (Random.value > 0.5f) {
            // Attack a random body part
            BodyPartType bodyPartType = (BodyPartType)Random.Range(0, System.Enum.GetValues(typeof(BodyPartType)).Length);
            BodyPart bodyPart = defender.BodyParts[bodyPartType];
            defender.TakeDamage(damage, bodyPartType);
            ApplyRandomEffect(bodyPart, defender);
            Debug.Log($"{attacker.name} hit {defender.name}'s {bodyPartType} for {damage} damage.");
            StartCoroutine(bodyPart.Flash()); // Flash the body part
        } else {
            // Attack overall health
            defender.TakeDamage(damage);
            Debug.Log($"{attacker.name} hit {defender.name} for {damage} damage.");
        }
    }


    private void ApplyRandomEffect(BodyPart bodyPart, Character character) {
        if (character.availableEffects.Count > 0) {
            StatusEffect randomEffect = character.availableEffects[Random.Range(0, character.availableEffects.Count)];
            bodyPart.ApplyEffect(randomEffect);
        } else {
            Debug.LogWarning("No available effects to apply.");
        }
    }
    
    private void ApplyRandomEffectToCharacter(Character character) {
        // Select a random effect from the character's available effects
        StatusEffect randomEffect = character.availableEffects[Random.Range(0, character.availableEffects.Count)];
        character.ApplyGlobalEffect(randomEffect);
    }
}