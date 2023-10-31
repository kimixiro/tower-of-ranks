using UnityEngine;

public class EndPhase : ITurnPhase
{
    public void Execute(Unit unit, Unit target, Environment currentEnvironment)
    {
        unit.UpdateStatusEffects();
        target.UpdateStatusEffects();
        unit.CheckForInjuries();
        target.CheckForInjuries();
        float roll = UnityEngine.Random.Range(0f, 1f);
        if (roll <= 0.2f)
        {
            CriticalHit crit = new CriticalHit(10, BodyPart.State.Bleeding);
            target.ApplyCriticalHitToBodyPart("Head", crit);
        }
    }
}