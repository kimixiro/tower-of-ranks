using System;

[Serializable]
public struct LightingCondition : IEquatable<LightingCondition>
{
    public Lighting lighting;
    public bool isNaturalLight;

    public LightingCondition(Lighting lighting, bool isNaturalLight)
    {
        this.lighting = lighting;
        this.isNaturalLight = isNaturalLight;
    }

    public override bool Equals(object obj)
    {
        if (obj is LightingCondition)
        {
            return Equals((LightingCondition)obj);
        }
        return false;
    }

    public bool Equals(LightingCondition other)
    {
        return lighting == other.lighting && isNaturalLight == other.isNaturalLight;
    }

    public override int GetHashCode()
    {
        return lighting.GetHashCode() ^ isNaturalLight.GetHashCode();
    }

    public static bool operator ==(LightingCondition left, LightingCondition right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(LightingCondition left, LightingCondition right)
    {
        return !(left == right);
    }
}