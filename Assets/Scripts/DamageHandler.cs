public class DamageHandler
{
    private UnitConfig config;

    public DamageHandler(UnitConfig config)
    {
        this.config = config;
    }

    public void HandleDamage(int damage)
    {
        config.hitPoints -= damage;
        if (config.hitPoints <= 0)
        {
            // Handle unit death
        }
    }

    public void ApplyDamageToBodyPart(string bodyPartName, int damageAmount, DamageType damageType)
    {
        // Logic for applying damage to specific body parts
    }

    public void CheckForMortalWound()
    {
        // Logic for checking and applying mortal wounds
    }
}