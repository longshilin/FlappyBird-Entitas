using System.Collections.Generic;
using Configuration;
using Entitas;
using UnityEngine;

namespace Pipe
{
    public sealed class PipeSpawnSystem : IExecuteSystem
    {
        readonly Contexts _contexts;
        private float _time;
        private bool _gameRunning;

        public PipeSpawnSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Execute()
        {
            _gameRunning = _contexts.game.GetGroup(GameMatcher.GameStarted)?.count > 0;

            if (!_gameRunning) return;

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
    }
}