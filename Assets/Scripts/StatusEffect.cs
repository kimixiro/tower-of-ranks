using UnityEngine;

[CreateAssetMenu(fileName = "NewStatusEffect", menuName = "Status Effect/New Effect")]
public class StatusEffect : ScriptableObject {
    public string effectName;
    public string description;
    public Sprite icon;
    public bool isGlobal;
    public float duration;
    // Additional fields like impact on stats, visual effects, etc.
}