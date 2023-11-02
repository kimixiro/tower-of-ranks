using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private List<Character> combatants;
    private int currentTurnIndex;

    // Constructor is not used in Unity, instead, we use Awake or Start for initialization
    void Start()
    {
        // Initialize combatants list and currentTurnIndex here if needed
        // For example, you could find all characters in the scene or set them through the inspector
        currentTurnIndex = 0;
    }

    public void StartBattle()
    {
        // Initialize battle conditions, such as turn order based on character attributes like speed
        // For simplicity, we'll assume combatants are already sorted by their initiative attribute
    }

    public void EndBattle()
    {
        // Handle end of battle logic, such as distributing experience points, loot, etc.
    }

    public void TakeTurn()
    {
        // Get the current character whose turn it is
        Character currentCharacter = combatants[currentTurnIndex];

        // Determine action - for now, we'll just have them attack a random enemy
        // In a full game, this would involve more complex decision making or player input
        Character target = SelectTarget(currentCharacter);
        if (target != null)
        {
            currentCharacter.Attack(target);
        }

        // Apply end-of-turn status effects, like poison or regeneration
        ApplyStatusEffects(currentCharacter);

        // Move to the next character's turn
        currentTurnIndex = (currentTurnIndex + 1) % combatants.Count;

        // Check for end of battle conditions
        if (combatants.All(c => c.IsDefeated()))
        {
            EndBattle();
        }
    }

    private Character SelectTarget(Character attacker)
    {
        // Select a random target that is not the attacker and not defeated
        var potentialTargets = combatants.Where(c => c != attacker && !c.IsDefeated()).ToList();
        if (potentialTargets.Any())
        {
            return potentialTargets[Random.Range(0, potentialTargets.Count)];
        }
        return null;
    }

    private void ApplyStatusEffects(Character character)
    {
        foreach (var effect in character.StatusEffects.ToList())
        {
            effect.Apply(character);
            effect.Duration--;

            // Remove effect if duration has expired
            if (effect.Duration <= 0)
            {
                effect.Remove(character);
            }
        }
    }
}