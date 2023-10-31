using UnityEngine;

public class EndPhase : ITurnPhase
{
    public void Execute(Unit  unit, Unit  target)
    {
        // Logic for the end of the turn
        Debug.Log(unit.name + " End Phase");
    }
}