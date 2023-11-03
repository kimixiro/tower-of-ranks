using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public enum BodyPartType { Head, Torso, ArmL, ArmR, LegL, LegR }

public class BodyPart : MonoBehaviour {
    public BodyPartType type;
    public int maxHealth;
    public int currentHealth;
    public List<StatusEffect> localizedEffects;
    private Renderer bodyPartRenderer;

    public delegate void EffectAppliedHandler(StatusEffect effect);
    public event EffectAppliedHandler OnEffectApplied;

    private void Awake() {
        localizedEffects = new List<StatusEffect>();
        bodyPartRenderer = GetComponent<Renderer>();
        UpdateRenderingState();
    }
    
    public void InitializeHealth(int health) {
        maxHealth = health;
        currentHealth = health;
        UpdateRenderingState();
    }
    
    public void TakeDamage(int damage) {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        if (currentHealth <= 0) {
            DisableBodyPart();
        } else {
            UpdateRenderingState(); // Ensure the body part is rendered if health is above zero
        }
    }
    
    private void DisableBodyPart() {
        // Disable rendering of the body part
        if (bodyPartRenderer != null) {
            bodyPartRenderer.enabled = false;
        }
        Debug.Log($"{type} has been disabled.");
    }

    private void UpdateRenderingState() {
        // Enable or disable rendering based on current health
        if (bodyPartRenderer != null) {
            bodyPartRenderer.enabled = currentHealth > 0;
        }
    }

    public void ApplyEffect(StatusEffect effect) {
        localizedEffects.Add(effect);
        OnEffectApplied?.Invoke(effect);
        // Handle the application of the effect, such as reducing health or mobility
    }
    
    public IEnumerator Flash() {
        Renderer renderer = GetComponent<Renderer>();
        Color originalColor = renderer.material.color;
        Color flashColor = Color.red; // Choose the flash color

        // Flash the body part by changing the color
        renderer.material.color = flashColor;
        yield return new WaitForSeconds(0.1f); // Duration of the flash
        renderer.material.color = originalColor;
    }

    // Additional methods for managing health and effects
}