public class StartPhase : ITurnPhase
{
    public void Execute(Unit unit, Unit target, Environment currentEnvironment)
    {
        unit.conditionManager.CheckForConditionEffects();
        target.conditionManager.CheckForConditionEffects();
        unit.CheckForEnvironmentalEffects(currentEnvironment);
        target.CheckForEnvironmentalEffects(currentEnvironment);
        unit.mentalStateManager.CheckMoraleEffects();
        target.mentalStateManager.CheckMoraleEffects();
    }
}