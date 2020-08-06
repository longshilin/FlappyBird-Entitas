using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PlayerSpawnSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    readonly Contexts _contexts;

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Player);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPlayer;
    }

    protected override void Execute(List<GameEntity> entities)
    {
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();

        entity.isPlayer = true;

        entity.AddVelocity(Vector3.zero);
        entity.AddPosition(Vector3.zero);
        entity.AddRotation(Quaternion.identity);
        entity.AddScale(Vector3.one);
        entity.AddAsset("Bird");
    }

    public PlayerSpawnSystem(IContext<GameEntity> context) : base(context)
    {
    }

    public PlayerSpawnSystem(ICollector<GameEntity> collector) : base(collector)
    {
    }

    public PlayerSpawnSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }
}