using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    public string effectName;
    public string description;
    public Sprite icon;
    public float duration; // Duration in turns or seconds
    public bool isGlobal; // Indicates if the effect is global or local

    // Apply the effect to a character or body part
    public abstract void ApplyEffect(Character character);
    public abstract void ApplyEffect(BodyPart bodyPart);

    // Remove the effect from a character or body part
    public abstract void RemoveEffect(Character character);
    public abstract void RemoveEffect(BodyPart bodyPart);

    // Modify the effect based on character attributes
    public virtual void ModifyEffectByAttributes(Character character)
    {
        // Logic to modify the effect based on character attributes
    }
}