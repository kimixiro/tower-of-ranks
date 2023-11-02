public class Attribute
{
    public string Name { get; set; }
    public int Value { get; set; }
    public int Modifier { get; set; }

    public Attribute(string name, int value, int modifier)
    {
        Name = name;
        Value = value;
        Modifier = modifier;
    }
}