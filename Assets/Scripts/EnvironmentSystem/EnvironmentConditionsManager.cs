using System.Collections.Generic;

public class EnvironmentConditionsManager
{
    // A dictionary to hold the environmental effects and their corresponding conditions
    public EnvironmentalEffects environmentalEffects;

    public EnvironmentConditionsManager(EnvironmentalEffects environmentalEffects)
    {
        this.environmentalEffects = environmentalEffects;
    }

    // This method checks the current EnvironmentalProfile and returns the effects to be applied
public List<EnvironmentalEffect> CheckEnvironmentalEffects(EnvironmentalProfile profile)
    {
        List<EnvironmentalEffect> effectsToApply = new List<EnvironmentalEffect>();

        // Iterate through the list of effects and apply them based on the conditions
        foreach (var effect in environmentalEffects.effectsList)
        {
            switch (effect.name)
            {
                case "Dehydration":
                    if (ShouldApplyDehydration(profile))
                    {
                        effectsToApply.Add(new EnvironmentalEffect(effect));
                    }
                    break;
                case "Frostbite":
                    if (ShouldApplyFrostbite(profile))
                    {
                        effectsToApply.Add(new EnvironmentalEffect(effect));
                    }
                    break;
                case "Heatstroke":
                    if (ShouldApplyHeatstroke(profile))
                    {
                        effectsToApply.Add(new EnvironmentalEffect(effect));
                    }
                    break;
                case "Hypothermia":
                    if (ShouldApplyHypothermia(profile))
                    {
                        effectsToApply.Add(new EnvironmentalEffect(effect));
                    }
                    break;
                case "Snow Blindness":
                    if (ShouldApplySnowBlindness(profile))
                    {
                        effectsToApply.Add(new EnvironmentalEffect(effect));
                    }
                    break;
                case "Soaked":
                    if (ShouldApplySoaked(profile))
                    {
                        effectsToApply.Add(new EnvironmentalEffect(effect));
                    }
                    break;
                case "Sunburn":
                    if (ShouldApplySunburn(profile))
                    {
                        effectsToApply.Add(new EnvironmentalEffect(effect));
                    }
                    break;
                case "Windburn":
                    if (ShouldApplyWindburn(profile))
                    {
                        effectsToApply.Add(new EnvironmentalEffect(effect));
                    }
                    break;
                // Add other cases as needed for each environmental effect
            }
        }

        return effectsToApply;
    }

 private bool ShouldApplyDehydration(EnvironmentalProfile profile)
    {
        // Hot, dry, and calm conditions during the day can cause dehydration
        return profile.weatherProfile.timeOfDay == TimeOfDay.Day &&
               profile.weatherProfile.precipitation == Precipitation.Clear &&
               profile.weatherProfile.wind == Wind.Calm &&
               profile.environmentType == EnvironmentType.Surface;
    }

    private bool ShouldApplyFrostbite(EnvironmentalProfile profile)
    {
        // Frostbite is likely in snowy and stormy conditions
        return profile.weatherProfile.precipitation == Precipitation.Snow &&
               profile.weatherProfile.wind == Wind.Stormy;
    }

    private bool ShouldApplyHeatstroke(EnvironmentalProfile profile)
    {
        // Heatstroke can occur during the day in extremely hot environments
        return profile.weatherProfile.timeOfDay == TimeOfDay.Day &&
               profile.weatherProfile.precipitation == Precipitation.Clear &&
               profile.environmentType == EnvironmentType.Surface &&
               profile.lightingCondition.lighting == Lighting.Bright;
    }

    private bool ShouldApplyHypothermia(EnvironmentalProfile profile)
    {
        // Hypothermia can occur in cold, wet, and dark conditions
        return (profile.weatherProfile.precipitation == Precipitation.Rain ||
                profile.weatherProfile.precipitation == Precipitation.Snow) &&
               profile.lightingCondition.lighting == Lighting.Dark;
    }

    private bool ShouldApplySnowBlindness(EnvironmentalProfile profile)
    {
        // Bright snow during the day can cause snow blindness
        return profile.weatherProfile.precipitation == Precipitation.Snow &&
               profile.weatherProfile.timeOfDay == TimeOfDay.Day &&
               profile.lightingCondition.lighting == Lighting.Bright;
    }

    private bool ShouldApplySoaked(EnvironmentalProfile profile)
    {
        // Rain can leave characters soaked
        return profile.weatherProfile.precipitation == Precipitation.Rain;
    }

    private bool ShouldApplySunburn(EnvironmentalProfile profile)
    {
        // Sunburn is a risk in bright conditions without precipitation
        return profile.weatherProfile.timeOfDay == TimeOfDay.Day &&
               profile.weatherProfile.precipitation == Precipitation.Clear &&
               profile.lightingCondition.lighting == Lighting.Bright;
    }

    private bool ShouldApplyWindburn(EnvironmentalProfile profile)
    {
        // Windburn can occur in windy or stormy conditions
        return profile.weatherProfile.wind == Wind.Windy ||
               profile.weatherProfile.wind == Wind.Stormy;
    }

}
