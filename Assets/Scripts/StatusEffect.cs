using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class StatusEffect
{
    public string name;
    public int duration;
    public string effectType;
    public int potency;
    public List<Attribute> affectedAttributes;

    // Removed constructor in favor of Unity's serialization system

    // Apply method: Applies the effect to the target character
    public void Apply(Character target)
    {
        // Add the effect to the character's status effects
        target.statusEffects.Add(this);

        // Modify the character's attributes based on the effect
        foreach (var attribute in affectedAttributes)
        {
            // Find the corresponding attribute in the character and apply the modifier
            var targetAttribute = target.primaryAttributes
                .Concat(target.secondaryAttributes)
                .FirstOrDefault(attr => attr.name == attribute.name);

            if (targetAttribute != null)
            {
                targetAttribute.modifier += attribute.modifier;
            }
        }
    }

    // Remove method: Removes the effect from the target character
    public void Remove(Character target)
    {
        // Remove the effect from the character's status effects
        target.statusEffects.Remove(this);

        // Revert the character's attributes based on the effect
        foreach (var attribute in affectedAttributes)
        {
            var targetAttribute = target.primaryAttributes
                .Concat(target.secondaryAttributes)
                .FirstOrDefault(attr => attr.name == attribute.name);

            if (targetAttribute != null)
            {
                targetAttribute.modifier -= attribute.modifier;
            }
        }
    }
}