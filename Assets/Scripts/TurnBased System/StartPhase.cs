using UnityEngine;

public class StartPhase : ITurnPhase
{
    public void Execute(Unit  unit, Unit  target)
    {
        // Logic for the start of the turn
        Debug.Log(unit.name + " Start Phase");
    }
}