[System.Serializable]
public class Equipment
{
    public string name;
    public string description;
    public int attackBonus;
    public int defenseBonus;

    public Equipment(string name, string description, int attackBonus, int defenseBonus)
    {
        this.name = name;
        this.description = description;
        this.attackBonus = attackBonus;
        this.defenseBonus = defenseBonus;
    }
}