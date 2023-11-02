public class DamageType
{
    public string Type { get; set; }
    public int Multiplier { get; set; }

    public DamageType(string type, int multiplier)
    {
        Type = type;
        Multiplier = multiplier;
    }
}