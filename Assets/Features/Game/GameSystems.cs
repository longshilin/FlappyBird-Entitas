public sealed class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        // player
        Add(new PlayerSystem(contexts));
        Add(new PlayerMovementSystem(contexts));

        // view
        Add(new SyncPositionSystem(contexts));
        Add(new ViewSystem(contexts));

        // events
        Add(new GameEventSystems(contexts));
        
        // input
        Add(new InputSystem(contexts));
    }
}