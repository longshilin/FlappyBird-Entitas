using System;
using Entitas;
using GeometryTowers.Configuration;
using GeometryTowers.Game;

namespace GeometryTowers.Assets.Features.Game
{
    public class GameController
    {
        readonly Systems _systems;

        public GameController(Contexts contexts, GameMapConfiguration gameMapConfiguration)
        {
            contexts.configuration.SetGameMapConfiguration(gameMapConfiguration);

            _systems = new GameSystems(contexts);
        }

        public void Initialize()
        {
            // This calls Initialize() on all sub systems
            _systems.Initialize();
        }

        public void Execute()
        {
            // This calls Execute() and Cleanup() on all sub systems
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}