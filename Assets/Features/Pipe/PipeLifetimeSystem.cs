using Entitas;
using UnityEngine;

public class PipeLifetimeSystem : IExecuteSystem
{
    readonly Contexts _contexts;

    public PipeLifetimeSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (!_contexts.game.isGameStarted) return;

        var configuration = _contexts.configuration.gameConfiguration.value;
        var group = _contexts.game.GetGroup(GameMatcher.Pipe);

        foreach (var gameEntity in group)
        {
            if (!gameEntity.isPipe) continue;

            if (gameEntity.pausable.Value) continue;

            var lifetime = gameEntity.lifeTime.Value;
            lifetime -= Time.deltaTime;

            if (lifetime <= 0)
            {
                gameEntity.isDestroyed = true;
            }
            else
            {
                gameEntity.ReplaceLifeTime(lifetime);
            }
        }
    }
}