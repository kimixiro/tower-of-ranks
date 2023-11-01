public class MentalStateManager
{
    private UnitConfig config;

    public MentalStateManager(UnitConfig config)
    {
        this.config = config;
    }

    public void IncreaseStress(int amount)
    {
        config.stressLevel += amount;
        CheckForStressEffects();
    }

    public void DecreaseStress(int amount)
    {
        config.stressLevel = System.Math.Max(config.stressLevel - amount, 0);
        CheckForStressEffects();
    }

    public void ModifyMorale(int amount)
    {
        config.morale += amount;
        // Implement any caps or minimums on morale here
    }

    public void CheckForStressEffects()
    {
        // Apply effects based on the stress level
        // For example, if stressLevel is above a certain threshold, apply a 'Shaken' condition
    }

    public void CheckMoraleEffects()
    {
        // Implement effects of morale on the unit's performance
        // For example, low morale could reduce attack accuracy
    }
}