public interface ITurnPhase
{
    void Execute(Unit unit, Unit target, Environment currentEnvironment);
}