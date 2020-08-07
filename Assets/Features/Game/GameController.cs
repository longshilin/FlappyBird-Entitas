using Configuration;
using Entitas;

public class GameController
{
    readonly Systems _systems;
    readonly Contexts _contexts;

    public GameController(Contexts contexts, IGameConfiguration configuration)
    {
        contexts.configuration.SetGameConfiguration(configuration);

        _contexts = contexts;
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