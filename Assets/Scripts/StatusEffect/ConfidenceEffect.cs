using UnityEngine;

[CreateAssetMenu(fileName = "ConfidenceEffect", menuName = "Combat/StatusEffects/ConfidenceEffect", order = 4)]
public class ConfidenceEffect : StatusEffect
{
    public int extraAttacks;
    public float strengthIncreasePercentage;

    public override bool CheckTriggerCondition(Combatant attacker, Combatant defender, int damage)
    {
        // Example: Trigger if damage is high
        return damage > 20;
    }

    public override void ApplyEffect(Combatant target)
    {
        // Example: Increase stats by a percentage
        target.config.strength = (int)(target.config.strength * (1 + strengthIncreasePercentage / 100.0f));
    }

    public override bool CheckResolutionCondition(Combatant target)
    {
        // Example: Automatically resolve (you can define your own condition)
        return true;
    }
}