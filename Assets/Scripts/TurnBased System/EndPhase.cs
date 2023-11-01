using UnityEngine;

public class EndPhase : ITurnPhase
{
    public void Execute(Unit unit, Unit target, Environment currentEnvironment)
    {
        unit.statusEffectManager.UpdateStatusEffects();
        target.statusEffectManager.UpdateStatusEffects();
        unit.CheckForInjuries();
        target.CheckForInjuries();
        if (DiceRoller.RollFloat() <= 0.2f)
        {
            CriticalHit crit = new CriticalHit(10, BodyPart.State.Bleeding);
            target.ApplyCriticalHitToBodyPart("Head", crit);
        }
    }
}