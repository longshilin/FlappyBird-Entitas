//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int GeometryTowersMapGameMap = 0;
    public const int GeometryTowersMapTilePosition = 1;
    public const int GeometryTowersTile = 2;

    public const int TotalComponents = 3;

    public static readonly string[] componentNames = {
        "GeometryTowersMapGameMap",
        "GeometryTowersMapTilePosition",
        "GeometryTowersTile"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(GeometryTowers.Map.GameMapComponent),
        typeof(GeometryTowers.Map.Tile.PositionComponent),
        typeof(GeometryTowers.TileComponent)
    };
}
