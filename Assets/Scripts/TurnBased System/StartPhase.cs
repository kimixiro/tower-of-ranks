public class StartPhase : ITurnPhase
{
    public void Execute(Unit unit, Unit target, Environment currentEnvironment)
    {
        unit.CheckForConditionEffects();
        target.CheckForConditionEffects();
        unit.CheckForEnvironmentalEffects(currentEnvironment);
        target.CheckForEnvironmentalEffects(currentEnvironment);
        unit.CheckMoraleEffects();
        target.CheckMoraleEffects();
    }
}