using Entitas;

public class GameController
{
    readonly Systems _systems;

    public GameController(Contexts contexts)
    {
        _systems = new GameSystems(contexts);
    }

    public void Initialize()
    {
        _systems.Initialize();
    }

    public void Execute()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}