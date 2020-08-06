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
            _time += Time.deltaTime;
        }
    }
}