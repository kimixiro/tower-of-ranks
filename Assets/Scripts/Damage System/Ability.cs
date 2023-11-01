[System.Serializable]
public class Ability
{
    public string name;
    public string description;
    public int cost; // Cost in some resource, e.g., action points or mana
    public int damage;

    public Ability(string name, string description, int cost, int damage)
    {
        this.name = name;
        this.description = description;
        this.cost = cost;
        this.damage = damage;
    }

    public void Execute(Unit user, Unit target)
    {
        // Implement the ability's effects here
    }
}