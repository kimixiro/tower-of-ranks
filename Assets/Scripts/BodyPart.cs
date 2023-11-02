using System.Collections.Generic;

public class BodyPart
{
    public string Name { get; set; }
    public int DamageThreshold { get; set; }
    public List<StatusEffect> StatusEffects { get; set; }

    public BodyPart(string name, int damageThreshold)
    {
        Name = name;
        DamageThreshold = damageThreshold;
        StatusEffects = new List<StatusEffect>();
    }

    public void TakeDamage(int damage)
    {
        // If damage exceeds the threshold, apply a status effect
        if (damage > DamageThreshold)
        {
            // Apply a status effect based on the type of damage and body part
            // For example, a severe cut might apply a bleeding effect
            StatusEffect severeInjury = new StatusEffect("Severe Injury", 3, "Bleeding", damage, new List<Attribute>());
            ApplyStatusEffect(severeInjury);
        }

        // Reduce the damage threshold to simulate injury
        DamageThreshold -= damage;
    }

    public void ApplyStatusEffect(StatusEffect effect)
    {
        // Add the effect to the list of status effects
        StatusEffects.Add(effect);
    }
}