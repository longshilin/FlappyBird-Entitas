using Pipe;

/// 游戏系统。
public sealed class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        // player
        Add(new PlayerSpawnSystem(contexts));
        Add(new PlayerMovementSystem(contexts));
        Add(new PlayerCollisionSystem(contexts));
        Add(new PlayerScoreSystem(contexts));

        // environment
        Add(new PipeSpawnSystem(contexts));
        Add(new PipeMovementSystem(contexts));
        Add(new PipeLifetimeSystem(contexts));

        // view
        Add(new SyncPositionSystem(contexts));
        Add(new ViewSystem(contexts));

        // events
        Add(new GameEventSystems(contexts));
        Add(new GameRestartSystem(contexts));

        // input
        Add(new InputSystem(contexts));
    }
}