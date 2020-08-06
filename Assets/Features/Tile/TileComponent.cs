using Entitas;
using GeometryTowers.Map.Tile;
using UnityEngine;

namespace GeometryTowers
{
    /// <summary>
    /// Basic map tile component
    /// </summary>
    public class TileComponent : IComponent
    {
        public GameTileType Type;
    }
}