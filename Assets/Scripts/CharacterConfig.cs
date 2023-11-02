using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterConfig", menuName = "Character Config", order = 0)]
public class CharacterConfig : ScriptableObject
{
    public string Name;
    public List<Attribute> PrimaryAttributes;
    public List<Attribute> SecondaryAttributes;
    public string Profession;

}