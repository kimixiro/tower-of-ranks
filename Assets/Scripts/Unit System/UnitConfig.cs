using System.Collections.Generic;

[System.Serializable]
public class UnitConfig
{
    public List<MortalWound> mortalWounds;
    public List<BodyPart> bodyParts;
    public List<Condition> activeConditions;
    public List<Ability> abilities;
    public List<Equipment> equippedItems;
    public List<StatusEffect> activeStatusEffects;
    public int stressLevel;
    public string unitName;
    public int combat;
    public int brawn;
    public int agility;
    public int intelligence;
    public int willpower;
    public int fellowship;
    public int hitPoints;
    public int actionPoints;
    public int perilThreshold;
    public int morale;
    // Add more attributes and skills as needed
}