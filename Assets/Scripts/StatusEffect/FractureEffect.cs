using UnityEngine;

[CreateAssetMenu(fileName = "FractureEffect", menuName = "Combat/StatusEffects/FractureEffect", order = 3)]
public class FractureEffect : StatusEffect
{
    public bool isPermanent = true;
    public float strengthReductionPercentage;

    public override bool CheckTriggerCondition(Combatant attacker, Combatant defender, int damage)
    {
        // Example: Trigger if damage is high and defender's physique is low
        return damage > 20 && defender.config.constitution < 10;
    }

    public override void ApplyEffect(Combatant target)
    {
        float reduction = strengthReductionPercentage; // Assume statReductionPercentage is a field
        target.config.strength = (int)(target.config.strength * (1 - reduction / 100.0f));

        Debug.Log($"Fear effect applied to {target.gameObject.name}. Strength reduced by {reduction}%.");
    }


    public override bool CheckResolutionCondition(Combatant target)
    {
        // Fracture cannot be resolved
        return !isPermanent;
    }
}