using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour {
    
    public CharacterAttributes attributes;
    public int maxHealth;
    private int currentHealth;
    public Dictionary<BodyPartType, BodyPart> BodyParts;
    public List<StatusEffect> ActiveGlobalEffects { get; private set; }
    public List<StatusEffect> availableEffects;

    public delegate void GlobalEffectAppliedHandler(StatusEffect effect);
    public event GlobalEffectAppliedHandler OnGlobalEffectApplied;
    
    public int CurrentHealth {
        get { return currentHealth; }
        private set {
            currentHealth = Mathf.Max(value, 0);
            if (currentHealth <= 0) {
                HandleDeath();
            }
        }
    }

    void Awake() {
        BodyParts = new Dictionary<BodyPartType, BodyPart>();
        ActiveGlobalEffects = new List<StatusEffect>();
        currentHealth = maxHealth;
        InitializeBodyParts();
    }

    private void InitializeBodyParts() {
        // Initialize body parts based on the character's GameObject structure
        // For example, find all BodyPart components attached to this character
        BodyPart[] parts = GetComponentsInChildren<BodyPart>();
        foreach (var part in parts) {
            BodyParts.Add(part.type, part);
        }
    }

    public void ApplyGlobalEffect(StatusEffect effect) {
        if (!ActiveGlobalEffects.Contains(effect)) {
            ActiveGlobalEffects.Add(effect);
            OnGlobalEffectApplied?.Invoke(effect);
            // Modify the effect based on attributes if necessary
            ModifyEffectBasedOnAttributes(effect);
        }
    }

    private void ModifyEffectBasedOnAttributes(StatusEffect effect) {
        // Adjust the effect based on the character's attributes
        // For example, a high Body attribute might reduce the duration of a poison effect
    }

    public void TakeDamage(int damage, BodyPartType? bodyPartType = null) {
        if (bodyPartType.HasValue) {
            // Apply damage to a specific body part
            BodyParts[bodyPartType.Value].TakeDamage(damage);
        } else {
            // Apply damage to overall health
            currentHealth -= damage;
            currentHealth = Mathf.Max(currentHealth, 0);
            if (currentHealth <= 0) {
                HandleDeath();
            }
        }
    }

    private void HandleDeath() {
        // Handle the character's death
        Debug.Log($"{gameObject.name} has died.");
        // Disable the character, trigger death animation, etc.
    }

    public void CalculateDerivedStats() {
        // Example calculations
        maxHealth = attributes.Body * 10;
        currentHealth = maxHealth;
        // Other stat calculations based on attributes
    }
    
    public void InvokeOnGlobalEffectApplied(StatusEffect effect) {
        OnGlobalEffectApplied?.Invoke(effect);
    }

    // You can add more methods here as needed for gameplay, like healing, managing effects, etc.
}
