namespace GeometryTowers.Map.Tile
{
    /// <summary>
    /// This map describes the different type of tiles
    /// that can exists within the maps
    /// </summary>
    public enum GameTileType
    {
        Empty = 1 << 0,
        Scenery = 1 << 1,
        BuildingSlot = 1 << 2,
        Path = 1 << 3,
        Spawn = 1 << 4,
        EndPoint = 1 << 5
    }
}