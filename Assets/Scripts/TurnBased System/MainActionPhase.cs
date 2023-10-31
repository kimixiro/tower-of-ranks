using UnityEngine;

public class MainActionPhase : ITurnPhase
{
    public void Execute(Unit unit, Unit target, Environment currentEnvironment)
    {
        int unitAttackBonus = unit.CalculateTotalAttackBonus();
        int targetDefenseBonus = target.CalculateTotalDefenseBonus();
        if (unit.config.abilities.Count > 0)
        {
            Ability ability = unit.config.abilities[0];
            unit.UseAbility(ability, target);
        }
    }
}