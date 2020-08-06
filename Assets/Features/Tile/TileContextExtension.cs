﻿using GeometryTowers.Map.Tile;
using UnityEngine;

namespace GeometryTowers.Tile
{
    public static class TileContextExtension
    {
        public static GameEntity CreateTile(this GameContext context, int x, int y)
        {
            var e = context.CreateEntity();
            e.AddGeometryTowersTile(GameTileType.Empty);
            e.AddGeometryTowersMapTilePosition(new Vector2(x, y));
            return e;
        }
    }
}