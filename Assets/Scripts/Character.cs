using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour {
    
    public CharacterAttributes attributes;
    public Dictionary<BodyPartType, BodyPart> BodyParts;
    [SerializeField] private int totalHealth;
    public List<StatusEffect> ActiveGlobalEffects { get; private set; }
    public List<StatusEffect> availableEffects;

    public delegate void GlobalEffectAppliedHandler(StatusEffect effect);
    public event GlobalEffectAppliedHandler OnGlobalEffectApplied;
    
    public int TotalHealth {
        get { return totalHealth; }
        private set { totalHealth = value; }
    }

    void Awake() {
        BodyParts = new Dictionary<BodyPartType, BodyPart>();
        ActiveGlobalEffects = new List<StatusEffect>();
        InitializeBodyParts();
        UpdateTotalHealth();
    }

    private void InitializeBodyParts() {
        // Initialize body parts based on the character's GameObject structure
        // For example, find all BodyPart components attached to this character
        BodyPart[] parts = GetComponentsInChildren<BodyPart>();
        foreach (var part in parts) {
            part.InitializeHealth(attributes.Body * 10);
            BodyParts.Add(part.type, part);
        }
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
            // Apply damage evenly across all body parts or to random body parts
            DistributeDamage(damage);
        }

        // Check if the character is still alive after taking damage
        if (TotalHealth <= 0) {
            HandleDeath();
        }
        
        UpdateTotalHealth();
    }
    
    private void DistributeDamage(int damage) {
        // This method will distribute damage across body parts
        // You can implement this based on your game's logic
    }

    private void HandleDeath() {
        // Handle the character's death
        Debug.Log($"{gameObject.name} has died.");
        // Disable the character, trigger death animation, etc.
    }
    
    public void InvokeOnGlobalEffectApplied(StatusEffect effect) {
        OnGlobalEffectApplied?.Invoke(effect);
    }

    // You can add more methods here as needed for gameplay, like healing, managing effects, etc.
}
