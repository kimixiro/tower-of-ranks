using UnityEngine;
using Random = UnityEngine.Random;

public class AttributeSystem
{
    // Roll a d100 for various checks
    public int RollD100()
    {
        return Random.Range(1, 101);
    }

    // Perform a combat check using attacker's Combat attribute against a difficulty rating
    public bool CombatCheck(CharacterAttributes attackerAttributes, int difficultyRating)
    {
        int attackRoll = RollD100();

        // In Zweihander, rolling a '1' is always a critical success and '100' is always a critical failure
        if (attackRoll == 1)
        {
            return true; // Critical success
        }
        else if (attackRoll == 100)
        {
            return false; // Critical failure
        }

        // The attacker's chance to hit is their Combat attribute minus the difficulty rating
        // A successful hit occurs if the roll is equal to or less than this chance
        int chanceToHit = attackerAttributes.Combat - difficultyRating;
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
        int baseDifficulty = 50; // Base difficulty for an average task

        // Adjust difficulty based on defender's Dexterity or other defensive attributes
        int defenderModifier = defenderAttributes.Dexterity / 10; // Example modifier calculation

        // Adjust difficulty based on environmental factors
        int environmentalModifier = CalculateEnvironmentalModifier(environmentFactors);

        // Adjust difficulty based on status effects
        int statusEffectModifier = CalculateStatusEffectModifier(attackerAttributes);

        // Final difficulty rating calculation
        int difficultyRating = baseDifficulty + defenderModifier + environmentalModifier + statusEffectModifier;

        // Ensure difficulty rating is within a valid range if necessary
        difficultyRating = Mathf.Clamp(difficultyRating, 1, 100);

        return difficultyRating;
    }
    
    private int CalculateEnvironmentalModifier(EnvironmentManager environmentFactors)
    {
        int modifier = 0;
        // Add or subtract from the modifier based on environmental factors
        // For example:
        // if (environmentFactors.highGround) modifier -= 10;
        // if (environmentFactors.poorVisibility) modifier += 15;
        // ... and so on for other factors

        return modifier;
    }

    // Calculate status effect modifiers
    private int CalculateStatusEffectModifier(CharacterAttributes attributes)
    {
        int modifier = 0;
        // Adjust the modifier based on status effects
        // For example:
        // if (attributes.isBlinded) modifier += 20;
        // ... and so on for other status effects

        return modifier;
    }
}
