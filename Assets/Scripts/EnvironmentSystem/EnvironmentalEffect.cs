using System;

[Serializable]
public class EnvironmentalEffect
{
    public string name;
    public StatusEffect effect;
    public int turnsToApply;
    public EnvironmentalEffect(EnvironmentalEffect original)
    {
        name = original.name;
        effect = original.effect;
        turnsToApply = original.turnsToApply;
    }
}