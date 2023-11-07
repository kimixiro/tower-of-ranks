using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Character : MonoBehaviour {
    
    public CharacterAttributes attributes;
    public Dictionary<BodyPartType, BodyPart> BodyParts;
    [SerializeField] private int totalHealth;
    public bool IsDead { get; private set; } = false;
    public List<ActiveStatusEffect> ActiveGlobalEffects { get; private set; }

    public List<StatusEffect> availableEffects;

    private AttributeSystem attributeSystem = new AttributeSystem();
    public delegate void GlobalEffectAppliedHandler(StatusEffect effect);
    public event GlobalEffectAppliedHandler OnGlobalEffectApplied;
    
    public int TotalHealth {
        get { return totalHealth; }
        private set { totalHealth = value; }
    }

    void Awake() {
        ActiveGlobalEffects = new List<ActiveStatusEffect>();
        InitializeBodyParts();
        UpdateTotalHealth();
    }

    private void InitializeBodyParts()
    {
        BodyParts = new Dictionary<BodyPartType, BodyPart>();
        BodyPart[] parts = GetComponentsInChildren<BodyPart>();

        // First, add all body parts to the dictionary
        foreach (var part in parts)
        {
            if (!BodyParts.ContainsKey(part.type))
            {
                BodyParts.Add(part.type, part);
            }
        }

        // Now that all body parts are in the dictionary, calculate their health
        attributeSystem.CalculateBodyPartHealth(this);
    }
    
    private void OnValidate() {
        if (BodyParts != null) {
            TotalHealth = CalculateTotalHealth();
        }
    }

    private int CalculateTotalHealth() {
        int total = 0;
        foreach (var bodyPart in BodyParts.Values) {
            total += bodyPart.currentHealth;
        }
        return total;
    }
    
    public void UpdateTotalHealth() {
        TotalHealth = CalculateTotalHealth();
    }
    
    public void ApplyGlobalEffect(StatusEffect effect) {
        ActiveStatusEffect activeEffect = new ActiveStatusEffect(effect, effect.duration);
        if (!ActiveGlobalEffects.Any(ae => ae.effect == effect)) {
            ActiveGlobalEffects.Add(activeEffect);
            effect.ApplyEffect(this);
            OnGlobalEffectApplied?.Invoke(effect);
        }
    }

    private void ModifyEffectBasedOnAttributes(StatusEffect effect) {
       
    }

    public void TakeDamage(int damage, BodyPartType? bodyPartType = null) {
        if (bodyPartType.HasValue) {
            // Apply damage to a specific body part
            BodyPart affectedPart = BodyParts[bodyPartType.Value];
            affectedPart.TakeDamage(damage);
        
            // Check if the affected body part is vital and has been incapacitated
            if (affectedPart.currentHealth <= 0 && affectedPart.isVital) {
                HandleVitalPartIncapacitated(affectedPart);
                return; // Stop further execution since the character is dead
            }
        } else {
            // Apply damage evenly across all body parts or to random body parts
            DistributeDamage(damage);
        }

        // Update total health after applying damage
        UpdateTotalHealth();
    
        // Check if the character is still alive after taking damage
        if (TotalHealth <= 0) {
            HandleDeath();
        }
    }
    
    private void DistributeDamage(int damage) {
        // This method will distribute damage across body parts
        // You can implement this based on your game's logic
    }

    private void HandleDeath() {
        // Handle the character's death
        Debug.Log($"{gameObject.name} has died.");
        IsDead = true;
        // Disable the character, trigger death animation, etc.
    }
    
    public void InvokeOnGlobalEffectApplied(StatusEffect effect) {
        OnGlobalEffectApplied?.Invoke(effect);
    }
    
    public void HandleVitalPartIncapacitated(BodyPart vitalPart) {
        if (vitalPart.isVital) {
            Debug.Log($"{gameObject.name}'s vital part {vitalPart.type} has been incapacitated. Character has died.");
            HandleDeath();
        }
    }

    // You can add more methods here as needed for gameplay, like healing, managing effects, etc.
}
