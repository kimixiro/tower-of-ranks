public class EnvironmentalModifierCalculator
{
    public  int CalculateModifier(EnvironmentManager environmentManager)
    {
        int modifier = 0;

        // Time of Day Modifier
        switch (environmentManager.currentProfile.weatherProfile.timeOfDay)
        {
            case TimeOfDay.Day:
                modifier -= 5; // Easier to see during the day
                break;
            case TimeOfDay.Night:
                modifier += 10; // Harder to see at night
                break;
        }

        // Precipitation Modifier
        switch (environmentManager.currentProfile.weatherProfile.precipitation)
        {
            case Precipitation.Clear:
                modifier += 0; // No change
                break;
            case Precipitation.Rain:
                modifier += 5; // Slightly harder due to rain
                break;
            case Precipitation.Snow:
                modifier += 10; // Harder due to snow
                break;
            case Precipitation.Hail:
                modifier += 15; // Very difficult due to hail
                break;
        }

        // Wind Modifier
        switch (environmentManager.currentProfile.weatherProfile.wind)
        {
            case Wind.Calm:
                modifier += 0; // No change
                break;
            case Wind.Breezy:
                modifier += 3; // Minor difficulty due to wind
                break;
            case Wind.Windy:
                modifier += 7; // Moderate difficulty due to wind
                break;
            case Wind.Stormy:
                modifier += 12; // Significant difficulty due to stormy wind
                break;
        }

        // Environment Type Modifier
        switch (environmentManager.currentProfile.environmentType)
        {
            case EnvironmentType.Surface:
                modifier += 0; // Standard conditions
                break;
            case EnvironmentType.Forest:
                modifier += 5; // Forest can be tricky with uneven ground and obstructed view
                break;
            case EnvironmentType.Dungeon:
                modifier += 10; // Dark and potentially cramped
                break;
            case EnvironmentType.Cave:
                modifier += 15; // Dark and possibly slippery or uneven
                break;
        }

        // Lighting Modifier
        switch (environmentManager.currentProfile.lightingCondition.lighting)
        {
            case Lighting.Bright:
                modifier -= 5; // Bright lighting makes it easier to see
                break;
            case Lighting.Dim:
                modifier += 5; // Dim lighting can obscure vision
                break;
            case Lighting.Dark:
                modifier += 15; // Darkness significantly impairs vision
                break;
        }

        // Natural Light Modifier
        if (!environmentManager.currentProfile.lightingCondition.isNaturalLight)
        {
            modifier += 5; // Artificial lighting might not be as effective as natural light
        }

        return modifier;
    }
}