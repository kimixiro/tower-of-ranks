[System.Serializable]
public class StatusEffect
{
    public string name;
    public int duration; // Duration in turns
    public int effectStrength; // Effect strength (e.g., damage per turn for poison)

    public StatusEffect(string name, int duration, int effectStrength)
    {
        this.name = name;
        this.duration = duration;
        this.effectStrength = effectStrength;
    }

    public void ApplyEffect(Unit unit)
    {
        // Implement the effect's behavior here
    }
}