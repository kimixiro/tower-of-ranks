[System.Serializable]
public class MortalWound
{
    public string description;
    public int effectValue;
    public bool immediateEffect;

    public MortalWound(string description, int effectValue, bool immediateEffect)
    {
        this.description = description;
        this.effectValue = effectValue;
        this.immediateEffect = immediateEffect;
    }
}