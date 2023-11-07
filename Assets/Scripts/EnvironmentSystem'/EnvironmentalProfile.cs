using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnvironmentalProfile
{
    public WeatherProfile weatherProfile;
    public EnvironmentType environmentType;
    public LightingCondition lightingCondition;

    // Constructor to set default environment
    public EnvironmentalProfile()
    {
        weatherProfile = new WeatherProfile();
        environmentType = EnvironmentType.Surface;
        lightingCondition = new LightingCondition(Lighting.Bright, true);
    }

    // Method to update lighting based on environment and time of day
    public void UpdateLighting(TimeOfDay timeOfDay)
    {
        switch (environmentType)
        {
            case EnvironmentType.Surface:
                lightingCondition = (timeOfDay == TimeOfDay.Day) ? new LightingCondition(Lighting.Bright, true) : new LightingCondition(Lighting.Dark, false);
                break;
            case EnvironmentType.Forest:
                lightingCondition = new LightingCondition(Lighting.Dim, true);
                break;
            case EnvironmentType.Dungeon:
            case EnvironmentType.Cave:
                lightingCondition = new LightingCondition(Lighting.Dark, false);
                break;
        }
    }
}
