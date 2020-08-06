public sealed class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        Add(new PlayerSystem(contexts));
        Add(new GameEventSystems(contexts));
        Add(new SyncPositionSystem(contexts));
        Add(new ViewSystem(contexts));
    }
}