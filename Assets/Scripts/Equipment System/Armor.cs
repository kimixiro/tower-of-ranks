using System.Collections.Generic;

[System.Serializable]
public class Armor
{
    public string name;
    public Dictionary<DamageType, int> damageReduction;
    public float mortalWoundProtection;

    public Armor(string name, float mortalWoundProtection)
    {
        this.name = name;
        this.mortalWoundProtection = mortalWoundProtection;
        this.damageReduction = new Dictionary<DamageType, int>
        {
            { DamageType.Slashing, 0 },
            { DamageType.Piercing, 0 },
            { DamageType.Crushing, 0 },
            { DamageType.Elemental, 0 },
            { DamageType.Poison, 0 }
        };
    }
}