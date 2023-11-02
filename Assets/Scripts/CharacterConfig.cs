using System.Collections.Generic;

[System.Serializable]
public class CharacterConfig
{
    public string Name { get; set; }
    public List<Attribute> PrimaryAttributes { get; set; }
    public List<Attribute> SecondaryAttributes { get; set; }
    public string Profession { get; set; }

    public CharacterConfig(string name, List<Attribute> primaryAttributes, List<Attribute> secondaryAttributes, string profession)
    {
        Name = name;
        PrimaryAttributes = primaryAttributes;
        SecondaryAttributes = secondaryAttributes;
        Profession = profession;
    }
}