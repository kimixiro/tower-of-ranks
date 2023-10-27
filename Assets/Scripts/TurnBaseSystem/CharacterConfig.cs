using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Combat/CharacterConfig", order = 1)]
public class CharacterConfig : ScriptableObject
{
    public int baseHealth = 100;
    public int baseAttackPower = 10;
    public int strength;
    public int dexterity;
    public int constitution;

    public List<StatusEffect> statusEffects; // list of possible status effects
}