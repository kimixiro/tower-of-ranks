using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BodyPart
{
    public string name;
    public int damageThreshold;
    public List<StatusEffect> statusEffects = new List<StatusEffect>();

    // Removed constructor and replaced with Unity's serialization system

    public void TakeDamage(int damage)
    {
        // If damage exceeds the threshold, apply a status effect
        if (damage > damageThreshold)
        {
            // Apply a status effect based on the type of damage and body part
            // For example, a severe cut might apply a bleeding effect
            StatusEffect severeInjury = new StatusEffect("Severe Injury", 3, "Bleeding", damage);
            ApplyStatusEffect(severeInjury);
        }

        // Reduce the damage threshold to simulate injury
        damageThreshold -= damage;
    }

    public void ApplyStatusEffect(StatusEffect effect)
    {
        // Add the effect to the list of status effects
        statusEffects.Add(effect);
    }
}