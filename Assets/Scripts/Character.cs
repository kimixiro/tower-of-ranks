using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    public string characterName;
    public List<Attribute> primaryAttributes;
    public List<Attribute> secondaryAttributes;
    public string profession;
    public List<StatusEffect> statusEffects;
    public List<Equipment> equipments;
    public List<BodyPart> bodyParts;

    // Removed constructor in favor of Unity's serialization system

    // Attack method: Character attempts to hit another character
    public void Attack(Character target)
    {
        // For simplicity, we'll just select a random body part to attack and use a base damage value
        BodyPart targetedBodyPart = target.SelectRandomBodyPart();
        int baseDamage = 10; // Base damage can later be modified based on character's attributes and skills

        // Calculate the damage on the targeted body part
        int damage = CalculateDamage(baseDamage, targetedBodyPart);

        // Apply the damage to the targeted body part
        targetedBodyPart.TakeDamage(damage);
    }

    // Defend method: Implementation of defend logic
    public void Defend()
    {
        // Implementation of defend logic
    }

    // ApplyStatusEffect method: Implementation of applying a status effect
    public void ApplyStatusEffect(StatusEffect effect)
    {
        // Implementation of applying a status effect
    }

    // CalculateDamage method: Calculates the damage based on the body part and any modifiers
    public int CalculateDamage(int baseDamage, BodyPart targetPart)
    {
        // Check for any damage modifiers based on body part or character's attributes
        int damageModifier = targetPart.damageThreshold; // Simplified example, would be more complex with actual game mechanics

        // Calculate final damage
        int finalDamage = baseDamage - damageModifier;

        // Ensure damage is not negative
        return Math.Max(finalDamage, 0);
    }
    
    // SelectRandomBodyPart method: Selects a random body part from the character's body parts
    public BodyPart SelectRandomBodyPart()
    {
        int index = Random.Range(0, bodyParts.Count);
        return bodyParts[index];
    }

    // IsDefeated method: Check if all body parts are defeated
    public bool IsDefeated()
    {
        // Check if all body parts are defeated
        return bodyParts.All(part => part.damageThreshold <= 0);
    }
}
