public class EnvironmentManager
{
    private UnitConfig config;

    public EnvironmentManager(UnitConfig config)
    {
        this.config = config;
    }

    public void ApplyEffects(Environment environment)
    {
        // Logic for applying environmental effects
        // For example, if the unit is in a desert, apply a 'Heat' condition
        if (environment.type == EnvironmentType.Desert)
        {
            config.activeConditions.Add(new Condition("Heat"));
        }
    }

    public void CheckForEnvironmentalEffects()
    {
        // Logic for checking and applying environmental effects based on the current environment
        // For example, remove 'Heat' condition if the unit moves out of a desert
    }
}