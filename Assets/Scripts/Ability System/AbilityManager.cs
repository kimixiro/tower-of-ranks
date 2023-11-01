using System.Collections.Generic;

public class AbilityManager
{
    private UnitConfig config;

    public AbilityManager(UnitConfig config)
    {
        this.config = config;
    }

    public bool CanUseAbility(Ability ability)
    {
        // Logic to check if the ability can be used
        // For example, check if the unit has enough energy or meets other conditions
        return true;
    }

    public void UseAbility(Ability ability, Unit target)
    {
        // Logic for using the ability
        // For example, apply damage or conditions to the target
        target.TakeDamage(ability.damage);
    }

    public List<Ability> GetAvailableAbilities()
    {
        // Logic to get a list of abilities that can be used
        return config.abilities;
    }
}