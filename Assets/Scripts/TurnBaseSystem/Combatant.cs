using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Combatant : MonoBehaviour
{
    public CharacterConfig config;
    public int currentHealth;
    public Renderer rend;
    
    public List<StatusEffect> activeEffects = new List<StatusEffect>(); // active status effects

    private bool isBlinking = false;
    private float blinkDuration = 0.2f;

    void Start()
    {
        currentHealth = config.baseHealth + config.constitution * 2;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Remaining health: {currentHealth}");
        StartCoroutine(Blink());
    }
    
    public void ApplyEffect(StatusEffect newEffect)
    {
        // Check if the effect can stack
        if (newEffect.canStack)
        {
            activeEffects.Add(Instantiate(newEffect)); // Clone to allow individual properties
            Debug.Log($"Effect {newEffect.effectType} applied to {gameObject.name}. It can stack.");
        }
        else
        {
            // Check if the effect is already active
            if (!activeEffects.Exists(effect => effect.effectType == newEffect.effectType))
            {
                activeEffects.Add(Instantiate(newEffect)); // Clone to allow individual properties
                Debug.Log($"Effect {newEffect.effectType} applied to {gameObject.name}. It cannot stack.");
            }
            else
            {
                Debug.Log($"Effect {newEffect.effectType} already active on {gameObject.name}. Skipping.");
            }
        }
    }

    public void ProcessEffects()
    {
        List<StatusEffect> effectsToRemove = new List<StatusEffect>();

        Debug.Log($"Processing effects for {gameObject.name}");

        foreach (StatusEffect effect in activeEffects)
        {
            effect.ApplyEffect(this);
            Debug.Log($"Applied {effect.effectType} to {gameObject.name}");

            if (effect.CheckResolutionCondition(this))
            {
                effectsToRemove.Add(effect);
                Debug.Log($"Effect {effect.effectType} met resolution condition on {gameObject.name}");
            }
        }

        // Remove effects that have met their resolution conditions
        foreach (StatusEffect effect in effectsToRemove)
        {
            activeEffects.Remove(effect);
            Debug.Log($"Effect {effect.effectType} removed from {gameObject.name}");
        }
    }

    
    private IEnumerator Blink()
    {
        if (isBlinking) yield break;

        isBlinking = true;
        float endTime = Time.time + blinkDuration;

        while (Time.time < endTime)
        {
            rend.enabled = !rend.enabled;
            yield return new WaitForSeconds(0.1f);
        }

        rend.enabled = true;
        isBlinking = false;
    }
}