public interface IUnit
{
    UnitConfig Config { get; }
    void TakeDamage(int damage);
    void PerformAction(IUnit target);
    // Add more methods as needed
}