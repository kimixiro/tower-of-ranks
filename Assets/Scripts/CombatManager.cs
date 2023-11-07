// CombatManager.cs

using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour {
    public Character player;
    public Character enemy;
    public StatusEffectManager statusEffectManager;
    public EnvironmentManager environmentManager;
    private AttributeSystem attributeSystem = new AttributeSystem();
    
    private void Start() {
        environmentManager.AddCharacterToEnvironment(player);
        environmentManager.AddCharacterToEnvironment(enemy);
        StartCoroutine(CombatRoutine());
    }

    private IEnumerator CombatRoutine() {
        while (!player.IsDead && !enemy.IsDead) {
            environmentManager.UpdateEnvironment();
            // Player's turn
            yield return StartCoroutine(TurnRoutine(player, enemy));

            // Check for end of combat conditions
            if (enemy.IsDead) break;

            // Enemy's turn
            yield return StartCoroutine(TurnRoutine(enemy, player));

            // Check for end of combat conditions
            if (player.IsDead) break;

            // Wait for the end of the turn
            yield return new WaitForSeconds(1f);
        }

        // Handle end of combat (e.g., determine winner, clean up, etc.)
        HandleEndOfCombat();
    }
    
    private IEnumerator TurnRoutine(Character currentCharacter, Character opponent) {
        // Phase 1: Update Status Effects
        statusEffectManager.UpdateStatusEffects(currentCharacter);

        // Wait for status effects to update visually if needed
        yield return new WaitForSeconds(0.5f);

        // Phase 2: Perform Action (e.g., Attack)
        PerformAttack(currentCharacter, opponent);

        // Wait for the action to complete visually if needed
        yield return new WaitForSeconds(0.5f);
    }

    private void PerformAttack(Character attacker, Character defender) {
        // Determine if the attack hits using the attribute system
        var difficultyRating = attributeSystem.CalculateDifficultyRating(attacker.attributes,defender.attributes,environmentManager);
        bool doesHit = attributeSystem.CombatCheck(attacker.attributes, difficultyRating);

        if (doesHit) {
            // Calculate damage based on attacker's attributes
            int damage = attributeSystem.CalculateDamage(attacker.attributes);

            // Randomly select a body part to hit
            BodyPartType bodyPartType = (BodyPartType)Random.Range(0, System.Enum.GetValues(typeof(BodyPartType)).Length);
            BodyPart bodyPart = defender.BodyParts[bodyPartType];

            // Apply damage to the specific body part
            defender.TakeDamage(damage, bodyPartType);
            Debug.Log($"{attacker.name} hit {defender.name}'s {bodyPartType} for {damage} damage.");

            // Apply a random effect to the hit body part
            ApplyRandomEffect(attacker, defender, bodyPartType);
            StartCoroutine(bodyPart.Flash());
        } else {
            // Attack missed
            Debug.Log($"{attacker.name} missed the attack on {defender.name}.");
        }
    }
    
    private void ApplyRandomEffect(Character attacker, Character defender, BodyPartType bodyPartType) {
        // Select a random effect from the attacker's available effects
        StatusEffect randomEffect = attacker.availableEffects[Random.Range(0, attacker.availableEffects.Count)];
        // Apply the effect using the existing ApplyEffect method
        if (!randomEffect.isGlobal) {
            statusEffectManager.ApplyEffect(defender, randomEffect, bodyPartType);
        }
    }

    private void ApplyRandomGlobalEffect(Character attacker, Character defender) {
        // Select a random effect from the attacker's available effects
        StatusEffect randomEffect = attacker.availableEffects[Random.Range(0, attacker.availableEffects.Count)];
        // Apply the effect using the existing ApplyEffect method
        if (randomEffect.isGlobal) {
            statusEffectManager.ApplyEffect(defender, randomEffect);
        }
    }

    private void HandleEndOfCombat() {
        // Implement end of combat logic here
        // Example: Determine winner, update game state, etc.
    }
}
