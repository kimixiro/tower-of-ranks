using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterConfig", menuName = "Character Config", order = 0)]
public class CharacterConfig : ScriptableObject
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