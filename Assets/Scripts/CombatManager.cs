using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour {
    public Character player;
    public Character enemy;
    public StatusEffectManager statusEffectManager;

    private void Start() {
        StartCoroutine(CombatRoutine());
    }

    private IEnumerator CombatRoutine() {
        while (player.TotalHealth > 0 && enemy.TotalHealth > 0) {
            // Player's turn
            PerformAttack(player, enemy);
            UpdateStatusEffects(player);
            // Check for end of combat conditions
            if (CheckForEndOfCombat()) yield break;
        
            yield return new WaitForSeconds(1f); // Wait for the turn to end

            // Enemy's turn
            PerformAttack(enemy, player);
            UpdateStatusEffects(enemy);
            // Check for end of combat conditions
            if (CheckForEndOfCombat()) yield break;
        
            yield return new WaitForSeconds(1f); // Wait for the turn to end
        }
    }

    private void UpdateStatusEffects(Character character) {
        statusEffectManager.UpdateStatusEffects(character);
    }

    private bool CheckForEndOfCombat() {
        // Implement logic to check if combat should end, e.g., one of the characters has been defeated
        return player.TotalHealth <= 0 || enemy.TotalHealth <= 0;
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
            ApplyRandomEffect(defender); // Updated to pass only the defender
            Debug.Log($"{attacker.name} hit {defender.name}'s {bodyPartType} for {damage} damage.");
            StartCoroutine(bodyPart.Flash()); // Flash the body part
        } else {
            // Attack overall health
            defender.TakeDamage(damage);
            Debug.Log($"{attacker.name} hit {defender.name} for {damage} damage.");
        }
    }

    private void ApplyRandomEffect(Character character) {
        // Select a random effect from the character's available effects
        StatusEffect randomEffect = character.availableEffects[Random.Range(0, character.availableEffects.Count)];
        // Apply the effect using the existing ApplyEffect method
        statusEffectManager.ApplyEffect(character, randomEffect);
    }

}