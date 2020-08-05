using Entidades.Map;
using Entidades.Map.Tile;
using UnityEngine;
using Zenject;

namespace Entidades
{
    /// <summary>
    /// This class creates the game map
    /// </summary>
    public class GameMapInitializer : MonoBehaviour
    {
        [Inject] private GameMapConfiguration _gameMapConfiguration;
        private Contexts _contexts;

        private void Start()
        {
            _contexts = new Contexts();
            CreateMap();
        }

        private void CreateMap()
        {
            for (int i = 0; i < _gameMapConfiguration.Dimensions.x; i++)
            {
                for (int j = 0; j < _gameMapConfiguration.Dimensions.y; j++)
                {
                    var e = _contexts.game.CreateEntity();

                    CreateTile(e);
                }
            }
        }

        private void CreateTile(GameEntity gameEntity)
        {
            gameEntity.AddComponent(0, new TileComponent());
            gameEntity.AddComponent(1, new PositionComponent());
        }
    }
}