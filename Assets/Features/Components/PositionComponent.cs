using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace GeometryTowers.Components
{
    /// <summary>
    /// Actual position in the game
    /// </summary>
    [Event(EventTarget.Self)]
    public class PositionComponent : IComponent
    {
        public Vector2Int Value;
    }
}
