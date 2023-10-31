using UnityEngine;

public class MainActionPhase : ITurnPhase
{
    public void Execute(Unit  unit, Unit  target)
    {
        // Main action logic (e.g., attacking)
        Debug.Log(unit.name + " attacks " + target.name);
    }
}