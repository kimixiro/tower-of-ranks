using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewHypothermiaEffect", menuName = "Status Effect/Environment/Hypothermia")]
public class Hypothermia : StatusEffect
{
    public int damagePerTurn;

    // Apply the effect to a character
    public override void ApplyEffect(Character character)
    {
        character.TakeDamage(damagePerTurn);
        // Assuming duration is in turns, decrement here if your game loop calls this once per turn
    }

    // Apply the effect to a body part
    public override void ApplyEffect(BodyPart bodyPart)
    {
        bodyPart.TakeDamage(damagePerTurn);
        // Assuming duration is in turns, decrement here if your game loop calls this once per turn
    }

    public override void RemoveEffect(Character character)
    {
        // Any cleanup when the effect ends, if necessary for the character
    }

    public override void RemoveEffect(BodyPart bodyPart)
    {
        // Any cleanup when the effect ends, if necessary for the body part
    }
}
