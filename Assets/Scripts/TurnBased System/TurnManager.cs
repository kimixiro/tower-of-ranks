using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Unit player;
    public List<Unit> enemies;
    public Environment currentEnvironment;
    private int currentTurnIndex = 0; // 0 for player, 1-n for enemies

    private ITurnPhase startPhase;
    private ITurnPhase mainActionPhase;
    private ITurnPhase endPhase;

    void Start()
    {
        startPhase = new StartPhase();
        mainActionPhase = new MainActionPhase();
        endPhase = new EndPhase();
    }

    void Update()
    {
        if (currentTurnIndex == 0)
        {
            ExecuteTurn(player, ChooseRandomEnemy());
            currentTurnIndex = 1;
        }
        else
        {
            ExecuteTurn(enemies[currentTurnIndex - 1], player);
            currentTurnIndex = (currentTurnIndex >= enemies.Count) ? 0 : currentTurnIndex + 1;
        }
    }

    void ExecuteTurn(Unit unit, Unit target)
    {
        unit.CheckForConditionEffects();
        target.CheckForConditionEffects();
        unit.CheckForStressEffects();
        target.CheckForStressEffects();
        unit.CheckForEnvironmentalEffects(currentEnvironment);
        target.CheckForEnvironmentalEffects(currentEnvironment);
        
        int unitAttackBonus = unit.CalculateTotalAttackBonus();
        int targetDefenseBonus = target.CalculateTotalDefenseBonus();
        
        unit.CheckMoraleEffects();
        target.CheckMoraleEffects();
        
        startPhase.Execute(unit, target);
        mainActionPhase.Execute(unit, target);
        endPhase.Execute(unit, target);

        // Check for injuries to body parts
        unit.CheckForInjuries();
        target.CheckForInjuries();
        
        // Execute special ability (for demonstration, let's assume the unit uses the first ability in its list)
        if (unit.config.abilities.Count > 0)
        {
            Ability ability = unit.config.abilities[0];
            unit.UseAbility(ability, target);
        }
        
        unit.UpdateStatusEffects();
        target.UpdateStatusEffects();

        // Roll for critical hit (20% chance)
        float roll = UnityEngine.Random.Range(0f, 1f);
        if (roll <= 0.2f)
        {
            // Apply a sample critical hit
            CriticalHit crit = new CriticalHit(10, BodyPart.State.Bleeding);
            target.ApplyCriticalHitToBodyPart("Head", crit);
        }
    }
    Unit ChooseRandomEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Count);
        return enemies[randomIndex];
    }
}