using UnityEngine;
using Random = UnityEngine.Random;

public class AttributeSystem
{
    private EnvironmentalModifierCalculator environmentalCalculator = new EnvironmentalModifierCalculator();
    private StatusEffectModifierCalculator statusEffectCalculator = new StatusEffectModifierCalculator();

    // Roll a d100 for various checks
    public int RollD100()
    {
        return Random.Range(1, 101);
    }

    public bool CombatCheck(CharacterAttributes attackerAttributes, int difficultyRating)
    {
        int attackRoll = RollD100();

        if (attackRoll == 1)
        {
            return true; // Critical success
        }
        else if (attackRoll == 100)
        {
            return false; // Critical failure
        }

        int chanceToHit = attackerAttributes.Combat - difficultyRating;

        // Ensure there's always at least a small chance to hit, e.g., 5%
        chanceToHit = Mathf.Max(chanceToHit, 5);

        return attackRoll <= chanceToHit;
    }


    // Calculate damage based on the Body attribute and weapon damage
    public int CalculateDamage(CharacterAttributes attributes)
    {
        int baseDamage = RollDamageBasedOnBody(attributes.Body);
        int weaponDamage = RollWeaponDamage();

        return baseDamage + weaponDamage;
    }

    // Calculate base damage from the Body attribute
    private int RollDamageBasedOnBody(int bodyAttribute)
    {
        // Adjust the formula as needed based on your game's rules
        return bodyAttribute / 10;
    }

    // Roll weapon damage, assuming a weapon that does 1d6 damage
    private int RollWeaponDamage()
    {
        // Adjust the weapon damage based on your game's rules
        return Random.Range(1, 7);
    }

    // Calculate health for each body part based on the Body attribute
    public void CalculateBodyPartHealth(Character character)
    {
        foreach (var keyValuePair in character.BodyParts)
        {
            BodyPartType type = keyValuePair.Key;
            BodyPart bodyPart = keyValuePair.Value;

            int baseHealth = CalculateHealthFromAttributes(character.attributes);
            bodyPart.InitializeHealth(baseHealth);
        }
    }

    // Calculate health from attributes, adjust the formula as needed
    private int CalculateHealthFromAttributes(CharacterAttributes attributes)
    {
        // Adjust the base health calculation based on your game's rules
        return attributes.Body * 10;
    }
    
    public int CalculateDifficultyRating(CharacterAttributes attackerAttributes, CharacterAttributes defenderAttributes, EnvironmentManager environmentFactors)
    {
        int environmentalModifier = environmentalCalculator.CalculateModifier(environmentFactors);
        int statusEffectModifier = statusEffectCalculator.CalculateModifier(attackerAttributes);

        // Final difficulty rating calculation
        int difficultyRating = environmentalModifier + statusEffectModifier;

        // Ensure difficulty rating is within a valid range if necessary
        difficultyRating = Mathf.Clamp(difficultyRating, 1, 100);

        return difficultyRating;
    }
}
