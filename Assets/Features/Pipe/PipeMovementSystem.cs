using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Pipe
{
    public class PipeMovementSystem : ReactiveSystem<GameEntity>
    {
        readonly Contexts _contexts;

        public PipeMovementSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        public PipeMovementSystem(IContext<GameEntity> context) : base(context)
        {
        }

        public PipeMovementSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Pipe);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPipe;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var configuration = _contexts.configuration.gameConfiguration.value;

            foreach (var gameEntity in entities)
            {
                if (!gameEntity.isPipe) continue;

                var pos = gameEntity.position.Value;
                gameEntity.ReplacePosition(pos + Vector3.right * Time.deltaTime * configuration.PipeMovementSpeed);
            }
        }
    }
}