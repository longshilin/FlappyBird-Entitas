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
        return context.CreateCollector(GameMatcher.Collision);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision && entity.isPlayer;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var player = _contexts.game.playerEntity;

        if (player.hasCollision && player.collision.Value != null)
        {
            var pausables = _contexts.game.GetGroup(GameMatcher.Pausable);

            foreach (var pausable in pausables)
            {
                pausable.ReplacePausable(true);
            }

            var e = _contexts.game.CreateEntity();
            e.isGameLost = true;
        }
    }
}