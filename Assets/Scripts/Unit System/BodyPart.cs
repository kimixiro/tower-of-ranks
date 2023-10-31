using System.Collections.Generic;

[System.Serializable]
public class BodyPart
{
    public enum State { Healthy, Injured, Bleeding, Infected, Severed }

    public string name;
    public int strength;
    public State currentState;
    public Dictionary<DamageType, int> resistances;
    public Armor equippedArmor;

    public BodyPart(string name, int strength)
    {
        this.name = name;
        this.strength = strength;
        this.currentState = State.Healthy;
        this.resistances = new Dictionary<DamageType, int>
        {
            { DamageType.Slashing, 0 },
            { DamageType.Piercing, 0 },
            { DamageType.Crushing, 0 },
            { DamageType.Elemental, 0 },
            { DamageType.Poison, 0 }
        };
    }
}