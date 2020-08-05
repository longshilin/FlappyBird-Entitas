using Entitas;
using UnityEngine;

namespace Entidades.Map.Tile
{
    public class PositionComponent : IComponent
    {
        [SerializeField] private Vector3 _position;
    }
}