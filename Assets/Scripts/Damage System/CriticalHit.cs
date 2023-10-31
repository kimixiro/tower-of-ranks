[System.Serializable]
public class CriticalHit
{
    public int extraDamage;
    public BodyPart.State appliedCondition;

    public CriticalHit(int extraDamage, BodyPart.State appliedCondition)
    {
        this.extraDamage = extraDamage;
        this.appliedCondition = appliedCondition;
    }
}