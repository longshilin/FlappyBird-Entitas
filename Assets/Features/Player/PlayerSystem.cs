using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PlayerSystem : ReactiveSystem<GameEntity>, IInitializeSystem
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
        entity.AddPosition(Vector3.zero);
        entity.AddRotation(Quaternion.identity);
        entity.AddScale(Vector3.one);
        entity.AddAsset("Bird");
    }

    public PlayerSystem(IContext<GameEntity> context) : base(context)
    {
    }

    public PlayerSystem(ICollector<GameEntity> collector) : base(collector)
    {
    }

    public PlayerSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }
}