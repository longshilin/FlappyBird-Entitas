using Configuration;
using Entitas;
using UnityEngine;

namespace Pipe
{
    public sealed class PipeSpawnSystem : IExecuteSystem
    {
        readonly Contexts _contexts;
        private float _time;

        public PipeSpawnSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Execute()
        {
            var configuration = _contexts.configuration.gameConfiguration;

            _time += Time.deltaTime;

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

            entity.AddPosition(Vector3.right * configuration.PipeOrigin);
            entity.AddRotation(Quaternion.identity);
            entity.AddScale(Vector3.one);
            entity.AddAsset("Pipe");
            entity.AddLifeTime(configuration.PipeLifetime);
        }
    }
}