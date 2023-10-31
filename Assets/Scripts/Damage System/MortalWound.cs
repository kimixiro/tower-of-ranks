[System.Serializable]
public class MortalWound
{
    public string description;
    public int attributePenalty;
    public bool isPermanent;

    public MortalWound(string description, int attributePenalty, bool isPermanent)
    {
        this.description = description;
        this.attributePenalty = attributePenalty;
        this.isPermanent = isPermanent;
    }
}