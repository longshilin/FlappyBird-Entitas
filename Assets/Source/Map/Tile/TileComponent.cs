using Entidades.Map.Tile;
using Entitas;
using UnityEngine;

namespace Entidades
{
    /// <summary>
    /// Basic map tile component
    /// </summary>
    public class TileComponent : IComponent
    {
        [SerializeField] private GameTileType _type;
    }
}