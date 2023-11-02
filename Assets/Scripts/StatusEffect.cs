using System.Collections.Generic;
using System.Linq;

public class StatusEffect
{
    public string Name { get; set; }
    public int Duration { get; set; }
    public string EffectType { get; set; }
    public int Potency { get; set; }
    public List<Attribute> AffectedAttributes { get; set; }

    public StatusEffect(string name, int duration, string effectType, int potency, List<Attribute> affectedAttributes)
    {
        Name = name;
        Duration = duration;
        EffectType = effectType;
        Potency = potency;
        AffectedAttributes = affectedAttributes;
    }

    // Apply method: Applies the effect to the target character
    public void Apply(Character target)
    {
        // Add the effect to the character's status effects
        target.StatusEffects.Add(this);

        // Modify the character's attributes based on the effect
        foreach (var attribute in AffectedAttributes)
        {
            // Find the corresponding attribute in the character and apply the modifier
            var targetAttribute = target.PrimaryAttributes
                .Concat(target.SecondaryAttributes)
                .FirstOrDefault(attr => attr.Name == attribute.Name);

            if (targetAttribute != null)
            {
                targetAttribute.Modifier += attribute.Modifier;
            }
        }
    }

// Remove method: Removes the effect from the target character
    public void Remove(Character target)
    {
        // Remove the effect from the character's status effects
        target.StatusEffects.Remove(this);

        // Revert the character's attributes based on the effect
        foreach (var attribute in AffectedAttributes)
        {
            var targetAttribute = target.PrimaryAttributes
                .Concat(target.SecondaryAttributes)
                .FirstOrDefault(attr => attr.Name == attribute.Name);

            if (targetAttribute != null)
            {
                targetAttribute.Modifier -= attribute.Modifier;
            }
        }
    }
    
}