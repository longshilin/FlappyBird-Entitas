using System.Collections.Generic;
using Entitas;

public sealed class GameRestartSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public GameRestartSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    public GameRestartSystem(IContext<GameEntity> context) : base(context)
    {
    }

    public GameRestartSystem(ICollector<GameEntity> collector) : base(collector)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameRestarted);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isGameRestarted;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        // destroy the player
        var player = _contexts.game.playerEntity;
        player.isDestroyed = true;

        // destroy the pipes
        var pipes = _contexts.game.GetGroup(GameMatcher.Pipe);

        foreach (var pipe in pipes)
        {
            pipe.isDestroyed = true;
        }

        // after removing previous entities, restart the game
        _contexts.game.isGameRestarted = false;
        _contexts.game.isGameLost = false;

        _contexts.game.isGameStarted = true;
    }
}