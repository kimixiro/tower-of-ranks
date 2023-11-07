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
    private EnvironmentalProfile previousProfile; 
    public StatusEffectManager statusEffectManager;
    public EnvironmentalEffects environmentalEffects;
    public List<EnvironmentalEffect> effectsToApply = new List<EnvironmentalEffect>();
    private EnvironmentConditionsManager conditionsManager;
    private List<Character> charactersInEnvironment = new List<Character>();

    // Initialize with default values or inject dependencies as needed
    void Start()
    {
        previousProfile = currentProfile;
        conditionsManager = new EnvironmentConditionsManager(environmentalEffects);
        effectsToApply = conditionsManager.CheckEnvironmentalEffects(currentProfile);
    }

    // Call this method every turn to update the environment and apply effects
    public void UpdateEnvironment()
    {
        // Check if the weather has changed before updating the effectsToApply list
        if (HasWeatherChanged())
        {
            effectsToApply = conditionsManager.CheckEnvironmentalEffects(currentProfile);
            previousProfile = currentProfile; // Update previousProfile after changes
        }

        // Create a list to keep track of effects that need to be removed
        List<EnvironmentalEffect> effectsToRemove = new List<EnvironmentalEffect>();

        // Update timers and apply effects
        foreach (var effect in effectsToApply)
        {
            effect.turnsToApply -= 1;

            if (effect.turnsToApply <= 0)
            {
                foreach (var character in charactersInEnvironment)
                {
                    // Check if the character already has the effect
                    if (!statusEffectManager.HasEffect(character, effect.effect))
                    {
                        // Apply the effect to the character
                        statusEffectManager.ApplyEffect(character, effect.effect);
                    }
                }
                // Mark the effect for removal
                effectsToRemove.Add(effect);
            }
        }

        // Remove effects that have been applied
        foreach (var effect in effectsToRemove)
        {
            effectsToApply.Remove(effect);
        }
    }
    
    private bool HasWeatherChanged()
    {
        // Compare the current profile with the previous profile
        if (previousProfile == null || currentProfile == null)
        {
            return true; // If either is null, we assume the weather has changed
        }

        // Check if any of the weather conditions have changed
        return previousProfile.weatherProfile.timeOfDay != currentProfile.weatherProfile.timeOfDay ||
               previousProfile.weatherProfile.precipitation != currentProfile.weatherProfile.precipitation ||
               previousProfile.weatherProfile.wind != currentProfile.weatherProfile.wind ||
               previousProfile.environmentType != currentProfile.environmentType ||
               previousProfile.lightingCondition != currentProfile.lightingCondition;
    }

    
    public void SetEnvironmentalProfile(EnvironmentalProfile profile)
    {
        // Set the new profile and update effects if the weather has changed
        if (currentProfile != profile)
        {
            currentProfile = profile;
            effectsToApply = conditionsManager.CheckEnvironmentalEffects(currentProfile);
        }
    }

    public void AddCharacterToEnvironment(Character character)
    {
        if (!charactersInEnvironment.Contains(character))
        {
            charactersInEnvironment.Add(character);
        }
    }

    public void RemoveCharacterFromEnvironment(Character character)
    {
        if (charactersInEnvironment.Contains(character))
        {
            charactersInEnvironment.Remove(character);
        }
    }
}