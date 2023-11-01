using System.Collections.Generic;

public class ConditionManager
{
    private UnitConfig config;

    public ConditionManager(UnitConfig config)
    {
        this.config = config;
    }

    public void ApplyCondition(Condition condition)
    {
        config.activeConditions.Add(condition);
    }

    public void RemoveCondition(Condition condition)
    {
        config.activeConditions.Remove(condition);
    }

    public void CheckForConditionEffects()
    {
        foreach (Condition condition in config.activeConditions)
        {
            // Apply effects based on the condition
            // For example, if the condition is 'Stunned', skip this unit's turn
        }
    }
}