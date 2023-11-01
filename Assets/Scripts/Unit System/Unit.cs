using UnityEngine;

public class Unit : MonoBehaviour, IUnit
{
    [SerializeField] internal UnitConfig config;

    public DamageHandler damageHandler;
    public EquipmentManager equipmentManager;
    public ConditionManager conditionManager;
    public MentalStateManager mentalStateManager;
    public AbilityManager abilityManager;
    public EnvironmentManager environmentManager;
    public StatusEffectManager statusEffectManager;
    
    public UnitConfig Config
    {
        get { return config; }
        set { config = value; }
    }

    void Start()
    {
        // Initialize various handlers with the unit's config
        damageHandler = new DamageHandler(config);
        equipmentManager = new EquipmentManager(config);
        conditionManager = new ConditionManager(config);
        mentalStateManager = new MentalStateManager(config);
        abilityManager = new AbilityManager(config);
        environmentManager = new EnvironmentManager(config);
    }

    // Delegate damage handling to DamageHandler
    public void TakeDamage(int damage)
    {
        damageHandler.HandleDamage(damage);
    }
    
    public void PerformAction(IUnit targetUnit)
    {
        // Implement the logic for performing an action on another unit
    }

    // Delegate equipment management to EquipmentManager
    public void EquipItem(Equipment item)
    {
        equipmentManager.EquipItem(item);
    }

    // Delegate condition handling to ConditionManager
    public void ApplyCondition(Condition condition)
    {
        conditionManager.ApplyCondition(condition);
    }

    // Delegate stress and morale management to MentalStateManager
    public void IncreaseStress(int amount)
    {
        mentalStateManager.IncreaseStress(amount);
    }

    public void ModifyMorale(int amount)
    {
        mentalStateManager.ModifyMorale(amount);
    }

    // Delegate ability usage to AbilityManager
    public void UseAbility(Ability ability, Unit target)
    {
        if (abilityManager.CanUseAbility(ability))
        {
            abilityManager.UseAbility(ability, target);
        }
    }

    // Delegate environmental effects to EnvironmentManager
    public void CheckForEnvironmentalEffects(Environment environment)
    {
        environmentManager.ApplyEffects(environment);
    }

    // ... add more delegating methods as needed
}
