using System.Collections.Generic;
using Entitas;

public class PlayerScoreSystem : ReactiveSystem<GameEntity>
{
    readonly Contexts _contexts;

    public PlayerScoreSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    public PlayerScoreSystem(IContext<GameEntity> context) : base(context)
    {
    }

    public PlayerScoreSystem(ICollector<GameEntity> collector) : base(collector)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.TriggerExit2D);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasTriggerExit2D && entity.isPlayer;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var player = _contexts.game.playerEntity;

        if (player.hasTriggerExit2D && player.triggerExit2D.Value != null)
        {
            var score = player.hasScore ? player.score.Value : 0;
            player.ReplaceScore(score + 1);
        }
    }
}