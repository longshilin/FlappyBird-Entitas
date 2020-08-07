using System.Collections.Generic;
using Configuration;
using Entitas;
using UnityEngine;

namespace Pipe
{
    public sealed class PipeSpawnSystem : IExecuteSystem, IAnyGameRestartedListener
    {
        readonly Contexts _contexts;
        private float _time;

        public PipeSpawnSystem(Contexts contexts)
        {
            _contexts = contexts;

            var restartListener = _contexts.game.CreateEntity();
            restartListener.AddAnyGameRestartedListener(this);
        }

        public void Execute()
        {
            if (!_contexts.game.isGameStarted) return;

            var configuration = _contexts.configuration.gameConfiguration;
            var player = _contexts.game.playerEntity;

            if (!player.pausable.Value)
            {
                _time += Time.deltaTime;
            }

            if (_time > configuration.value.PipeSpawnInterval)
            {
                CreatePipe(configuration.value);
                _time = 0f;
            }
        }

        private void CreatePipe(IGameConfiguration configuration)
        {
            var entity = _contexts.game.CreateEntity();

            entity.isPipe = true;

            entity.AddPosition
            (
                Vector3.right * configuration.PipeOrigin +
                Vector3.up * Random.Range(-configuration.PipeRandomHeightRange, configuration.PipeRandomHeightRange)
            );

            entity.AddRotation(Quaternion.identity);
            entity.AddScale(Vector3.one);
            entity.AddLifeTime(configuration.PipeLifetime);
            entity.AddPausable(false);
            entity.AddAsset("Pipe");
        }

        public void OnAnyGameRestarted(GameEntity entity)
        {
            _time = 0;
        }
    }
}