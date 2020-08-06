using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class PlayerMovementSystem : ReactiveSystem<InputEntity>
{
    readonly Contexts _contexts;

    public PlayerMovementSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    public PlayerMovementSystem(IContext<InputEntity> context) : base(context)
    {
    }

    public PlayerMovementSystem(ICollector<InputEntity> collector) : base(collector)
    {
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.MouseDown);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var player = _contexts.game.GetEntities(GameMatcher.Player);

        if (player != null && player.Length == 1)
        {
            var e = player[0];
            e.ReplaceVelocity(Vector3.up * 3f);
        }
    }
}