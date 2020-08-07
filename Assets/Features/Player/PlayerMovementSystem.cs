using System.Collections.Generic;
using Entitas;
using UnityEngine;

/// <summary>
/// Handles player entity movement logic
/// </summary>
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

    /// <summary>
    /// Adds upward velocity to the player
    /// </summary>
    /// <param name="entities"></param>
    protected override void Execute(List<InputEntity> entities)
    {
        if (!_contexts.game.isGameStarted) return;

        var player = _contexts.game.playerEntity;
        var config = _contexts.configuration.gameConfiguration;

        if (player == null || player.pausable.Value) return;

        player.ReplaceVelocity(Vector3.up * config.value.PlayerUpwardsVelocity);
    }
}