using UnityEngine;

[CreateAssetMenu(fileName = "BleedingEffect", menuName = "Combat/StatusEffects/BleedingEffect", order = 1)]
public class BleedingEffect : StatusEffect
{
    public int bleedDamage;
    public override bool CheckTriggerCondition(Combatant attacker, Combatant defender, int damage)
    {
        // Example: 20% chance to trigger Bleeding
        return Random.Range(0, 100) < 20;
    }

    public override void ApplyEffect(Combatant target)
    {
        int damage = bleedDamage; // Assume bleedDamage is a field that holds the damage value
        target.TakeDamage(damage); // Assume TakeDamage is a method that applies damage to the combatant

        Debug.Log($"Bleeding effect applied to {target.gameObject.name}. {damage} damage dealt.");
    }


    public override bool CheckResolutionCondition(Combatant target)
    {
        // Example: Physique check to remove effect
        return Random.Range(0, 100) < target.config.constitution * 2;
    }
}