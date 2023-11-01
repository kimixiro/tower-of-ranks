using UnityEngine;

public class MainActionPhase : ITurnPhase
{
    public void Execute(Unit unit, Unit target, Environment currentEnvironment)
    {
        int unitAttackBonus = unit.equipmentManager.CalculateTotalAttackBonus();
        int targetDefenseBonus = target.equipmentManager.CalculateTotalDefenseBonus();
        if (unit.config.abilities.Count > 0)
        {
            Ability ability = unit.config.abilities[0];
            unit.UseAbility(ability, target);
        }
    }
}