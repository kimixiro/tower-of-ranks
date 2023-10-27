using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    public enum EffectType { Bleeding, Fear, Fracture, Confidence }
    public EffectType effectType;
    public bool canStack;

    public abstract bool CheckTriggerCondition(Combatant attacker, Combatant defender, int damage);
    public abstract void ApplyEffect(Combatant target);
    public abstract bool CheckResolutionCondition(Combatant target);
}