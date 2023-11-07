using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnvironmentalEffects", menuName = "Environment/Effects")]
public class EnvironmentalEffects : ScriptableObject {
    public List<EnvironmentalEffect> effectsList;
}