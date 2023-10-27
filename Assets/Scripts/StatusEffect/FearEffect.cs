using UnityEngine;

[CreateAssetMenu(fileName = "FearEffect", menuName = "Combat/StatusEffects/FearEffect", order = 2)]
public class FearEffect : StatusEffect
{
    public float statReductionPercentage;
    public override bool CheckTriggerCondition(Combatant attacker, Combatant defender, int damage)
    {
        // Example: Trigger if defender's health is low
        return defender.currentHealth < 20;
    }

    public override void ApplyEffect(Combatant target)
    {
        // Example: Reduce stats by potency%
        target.config.strength = (int)(target.config.strength * (1 - statReductionPercentage / 100.0f));
    }

    public override bool CheckResolutionCondition(Combatant target)
    {
        // Example: Willpower check to remove effect
        return Random.Range(0, 100) < target.config.strength * 2;
    }
}