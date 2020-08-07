using Entitas;
using UnityEngine;

namespace Pipe
{
    public class PipeMovementSystem : IExecuteSystem
    {
        readonly Contexts _contexts;

        public PipeMovementSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Execute()
        {
            if (!_contexts.game.isGameStarted) return;

            var configuration = _contexts.configuration.gameConfiguration.value;
            var group = _contexts.game.GetGroup(GameMatcher.Pipe);

            foreach (var gameEntity in group)
            {
                if (!gameEntity.isPipe) continue;

                if (gameEntity.pausable.Value) continue;

                var pos = gameEntity.position.Value;
                pos -= Vector3.right * Time.deltaTime * configuration.PipeMovementSpeed;

                gameEntity.ReplacePosition(pos);
            }
        }
    }
}