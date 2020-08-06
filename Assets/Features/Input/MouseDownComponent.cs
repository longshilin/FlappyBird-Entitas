    using Entitas;
    using Entitas.CodeGeneration.Attributes;
    using UnityEngine;

    [Input, Cleanup(CleanupMode.DestroyEntity)]
public sealed class MouseDownComponent : IComponent
    {
        public Vector2 Value;
    }
