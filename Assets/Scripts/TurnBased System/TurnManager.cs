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
        
        startPhase.Execute(unit, target, currentEnvironment);
        mainActionPhase.Execute(unit, target, currentEnvironment);
        endPhase.Execute(unit, target, currentEnvironment);
    }
    Unit ChooseRandomEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Count);
        return enemies[randomIndex];
    }
}