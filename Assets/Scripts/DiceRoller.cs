public static class DiceRoller
{
    // Roll a float between 0 and 1
    public static float RollFloat()
    {
        return UnityEngine.Random.Range(0f, 1f);
    }

    // Roll an integer between min and max (inclusive)
    public static int RollInt(int min, int max)
    {
        return UnityEngine.Random.Range(min, max + 1);
    }

    // Roll for a check between two characters
    public static bool RollCheck(Character unit1, Character unit2, float threshold)
    {
        float roll = RollFloat();
        return roll <= threshold;
    }

    // Roll for a self-check for a single character
    public static bool RollSelfCheck(Character unit, float threshold)
    {
        float roll = RollFloat();
        return roll <= threshold;
    }
}