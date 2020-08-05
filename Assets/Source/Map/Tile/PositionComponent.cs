using Entitas;
using UnityEngine;

namespace Entidades.Map.Tile
{
    /// <summary>
    /// Game position component
    /// </summary>
    public class PositionComponent : IComponent
    {
        [SerializeField] private Vector2 _position;
    }
}