using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Character : MonoBehaviour
{
    public string Name { get; set; }
    public List<Attribute> PrimaryAttributes { get; set; }
    public List<Attribute> SecondaryAttributes { get; set; }
    public string Profession { get; set; }
    public List<StatusEffect> StatusEffects { get; set; }
    public List<Equipment> Equipments { get; set; }
    public List<BodyPart> BodyParts { get; set; }

    public Character(CharacterConfig config)
    {
        Name = config.Name;
        PrimaryAttributes = config.PrimaryAttributes;
        SecondaryAttributes = config.SecondaryAttributes;
        Profession = config.Profession;
        StatusEffects = new List<StatusEffect>();
        Equipments = new List<Equipment>();
        BodyParts = new List<BodyPart>();
    }

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


    public void Defend()
    {
        // Implementation of defend logic
    }

    public void ApplyStatusEffect(StatusEffect effect)
    {
        // Implementation of applying a status effect
    }

    // CalculateDamage method: Calculates the damage based on the body part and any modifiers
    public int CalculateDamage(int baseDamage, BodyPart targetPart)
    {
        // Check for any damage modifiers based on body part or character's attributes
        int damageModifier = targetPart.DamageThreshold; // Simplified example, would be more complex with actual game mechanics

        // Calculate final damage
        int finalDamage = baseDamage - damageModifier;

        // Ensure damage is not negative
        return Math.Max(finalDamage, 0);
    }
    
    // SelectRandomBodyPart method: Selects a random body part from the character's body parts
    public BodyPart SelectRandomBodyPart()
    {
        Random rnd = new Random();
        int index = rnd.Next(BodyParts.Count);
        return BodyParts[index];
    }

    public bool IsDefeated()
    {
        // Check if all body parts are defeated
        return BodyParts.All(part => part.DamageThreshold <= 0);
    }
}