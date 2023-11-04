[System.Serializable]
public class ActiveStatusEffect
{
    public StatusEffect effect;
    public float remainingDuration;

    public ActiveStatusEffect(StatusEffect effect, float duration)
    {
        this.effect = effect;
        this.remainingDuration = duration;
    }
}