using System;
using UnityEngine;

public class Unit : MonoBehaviour, IUnit
{
    [SerializeField] internal UnitConfig config;
    

    public UnitConfig Config => config;

    public void TakeDamage(int damage)
    {
        config.hitPoints -= damage;
        if (config.hitPoints <= 0)
        {
            // Handle unit death
        }
    }

    public void PerformAction(IUnit target)
    {
        // Implement action logic based on unit's attributes and skills
    }
    
    public void ApplyMortalWound(MortalWound wound)
    {
        config.mortalWounds.Add(wound);
        // Apply attribute penalties or other immediate effects
    }
    
    public void CheckForMortalWound()
    {
        if (config.hitPoints <= 0)
        {
            // Roll for a mortal wound and apply it
            MortalWound wound = new MortalWound("Severe Bleeding", -2, false);
            ApplyMortalWound(wound);
        }
    }
    
    public void ApplyDamageToBodyPart(string bodyPartName, int damageAmount, DamageType damageType)
    {
        BodyPart part = config.bodyParts.Find(bp => bp.name == bodyPartName);
        if (part != null)
        {
            int resistance = part.resistances[damageType];
            int armorReduction = part.equippedArmor != null ? part.equippedArmor.damageReduction[damageType] : 0;
            int effectiveDamage = damageAmount - resistance - armorReduction;
            part.strength -= Math.Max(effectiveDamage, 0);
            // Check for state changes based on new strength value
        }
    }

    public void CheckForInjuries()
    {
        // Logic to check for injuries to body parts, e.g., after an attack
        // This could involve dice rolls, checking hit points, etc.
    }
    
    public void EquipArmorToBodyPart(string bodyPartName, Armor armor)
    {
        BodyPart part = config.bodyParts.Find(bp => bp.name == bodyPartName);
        if (part != null)
        {
            part.equippedArmor = armor;
        }
    }
    
    public void ApplyCriticalHitToBodyPart(string bodyPartName, CriticalHit criticalHit)
    {
        BodyPart part = config.bodyParts.Find(bp => bp.name == bodyPartName);
        if (part != null)
        {
            // Apply extra damage
            part.strength -= criticalHit.extraDamage;

            // Apply condition
            part.currentState = criticalHit.appliedCondition;

            // Check for state changes based on new strength value
        }
    }

    public void ApplyCondition(Condition condition)
    {
        config.activeConditions.Add(condition);
    }

    public void RemoveCondition(Condition condition)
    {
        config.activeConditions.Remove(condition);
    }

    public void CheckForConditionEffects()
    {
        foreach (Condition condition in config.activeConditions)
        {
            // Apply effects based on the condition
            // For example, if the condition is 'Stunned', skip this unit's turn
        }
    }
    
    public void IncreaseStress(int amount)
    {
        config.stressLevel += amount;
        CheckForStressEffects();
    }

    public void DecreaseStress(int amount)
    {
        config.stressLevel = Math.Max(config.stressLevel - amount, 0);
        CheckForStressEffects();
    }

    public void CheckForStressEffects()
    {
        // Apply effects based on the stress level
        // For example, if stressLevel is above a certain threshold, apply a 'Shaken' condition
    }
    
    public void CheckForEnvironmentalEffects(Environment environment)
    {
        // Apply effects based on the current environment
        // For example, if it's foggy, reduce accuracy
    }
    
    public bool CanUseAbility(Ability ability)
    {
        // Check if the unit has enough resources to use the ability
        return true; // Placeholder
    }

    public void UseAbility(Ability ability, Unit target)
    {
        if (CanUseAbility(ability))
        {
            ability.Execute(this, target);
            // Deduct the ability's cost from the unit's resources
        }
    }
    
    public void EquipItem(Equipment item)
    {
        config.equippedItems.Add(item);
    }

    public void UnequipItem(Equipment item)
    {
        config.equippedItems.Remove(item);
    }

    public int CalculateTotalAttackBonus()
    {
        int total = 0;
        foreach (Equipment item in config.equippedItems)
        {
            total += item.attackBonus;
        }
        return total;
    }

    public int CalculateTotalDefenseBonus()
    {
        int total = 0;
        foreach (Equipment item in config.equippedItems)
        {
            total += item.defenseBonus;
        }
        return total;
    }
    
    public void ApplyStatusEffect(StatusEffect effect)
    {
        config.activeStatusEffects.Add(effect);
    }

    public void RemoveStatusEffect(StatusEffect effect)
    {
        config.activeStatusEffects.Remove(effect);
    }

    public void UpdateStatusEffects()
    {
        foreach (StatusEffect effect in config.activeStatusEffects)
        {
            effect.ApplyEffect(this);
            effect.duration--;
            if (effect.duration <= 0)
            {
                RemoveStatusEffect(effect);
            }
        }
    }
    
    public void ModifyMorale(int amount)
    {
        config.morale += amount;
        // Implement any caps or minimums on morale here
    }

    public void CheckMoraleEffects()
    {
        // Implement effects of morale on the unit's performance
        // For example, low morale could reduce attack accuracy
    }


    // Add more methods as needed
}