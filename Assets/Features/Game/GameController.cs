using Configuration;
using Entitas;

public class GameController
{
    readonly Systems _systems;
    readonly Contexts _contexts;

    public GameController(Contexts contexts, IGameConfiguration configuration)
    {
        _contexts = contexts;
        _contexts.configuration.SetGameConfiguration(configuration);
        _systems = new GameSystems(_contexts);
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