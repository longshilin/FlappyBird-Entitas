using System.Collections.Generic;
using Entitas;

public class PlayerCollisionSystem : ReactiveSystem<GameEntity>
{
    readonly Contexts _contexts;

    public PlayerCollisionSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    public PlayerCollisionSystem(IContext<GameEntity> context) : base(context)
    {
    }

    public PlayerCollisionSystem(ICollector<GameEntity> collector) : base(collector)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CollisionEnter2D);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollisionEnter2D && entity.isPlayer;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var player = _contexts.game.playerEntity;

        if (player.hasCollisionEnter2D && player.collisionEnter2D.Value != null)
        {
            var pausables = _contexts.game.GetGroup(GameMatcher.Pausable);

            foreach (var pausable in pausables)
            {
                pausable.ReplacePausable(true);
            }

            _contexts.game.isGameLost = true;
            _contexts.game.isGameStarted = false;
        }
    }
}