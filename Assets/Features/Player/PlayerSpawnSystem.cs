using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PlayerSpawnSystem : ReactiveSystem<GameEntity>
{
    readonly Contexts _contexts;

    public void CreatePlayer()
    {
        var entity = _contexts.game.CreateEntity();
        var configuration = _contexts.configuration.gameConfiguration.value;

        entity.isPlayer = true;

        entity.AddVelocity(Vector3.zero);
        entity.AddPosition(Vector3.right * configuration.PlayerSpawnOrigin);
        entity.AddRotation(Quaternion.identity);
        entity.AddScale(Vector3.one);
        entity.AddPausable(false);
        entity.AddAsset("Bird");
    }

    public PlayerSpawnSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameEvent);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isGameEvent && entity.isGameStarted;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var gameEntity in entities)
        {
            if (gameEntity.isGameStarted)
            {
                CreatePlayer();
                return;
            }
        }
    }
}