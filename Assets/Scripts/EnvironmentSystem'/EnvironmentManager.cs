using System.Collections.Generic;
using UnityEngine;

public enum TimeOfDay { Day, Night }
public enum Precipitation { Clear, Rain, Snow, Hail }
public enum Wind { Calm, Breezy, Windy, Stormy }
public enum EnvironmentType { Surface, Forest, Dungeon, Cave }
public enum Lighting { Bright, Dim, Dark }

public class EnvironmentManager : MonoBehaviour
{
    public EnvironmentalProfile currentProfile;
    public StatusEffectManager statusEffectManager;
    public List<EnvironmentalEffect> effectsToApply = new List<EnvironmentalEffect>();
    private EnvironmentConditionsManager conditionsManager;
    private List<Character> charactersInEnvironment;

    // Initialize with default values or inject dependencies as needed
    void Start()
    {
        currentProfile = new EnvironmentalProfile(); // Set the initial environmental profile
        conditionsManager = new EnvironmentConditionsManager();
        charactersInEnvironment = new List<Character>(); // Populate this list with characters in the environment
    }

    // Call this method every turn to update the environment and apply effects
    public void UpdateEnvironment()
    {
        // Get the effects to apply from the conditions manager
         effectsToApply = conditionsManager.CheckEnvironmentalEffects(currentProfile);

        // Logic to update timers and apply effects
        foreach (var envEffect in effectsToApply)
        {
            foreach (var character in charactersInEnvironment)
            {
                // Decrement the timer and apply the effect if the timer reaches 0
                // This assumes that you have a method to apply the status effect to the character
                statusEffectManager.ApplyEffect(character, envEffect.effect);
            }
        }
    }

    // Method to set the current environmental profile
    public void SetEnvironmentalProfile(EnvironmentalProfile profile)
    {
        currentProfile = profile;
    }

    // Example method to add a character to the environment
    public void AddCharacterToEnvironment(Character character)
    {
        if (!charactersInEnvironment.Contains(character))
        {
            charactersInEnvironment.Add(character);
        }
    }

    // Example method to remove a character from the environment
    public void RemoveCharacterFromEnvironment(Character character)
    {
        if (charactersInEnvironment.Contains(character))
        {
            charactersInEnvironment.Remove(character);
        }
    }
}