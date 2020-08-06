using System.Collections.Generic;
using Entitas;
using GeometryTowers.Tile;
using UnityEngine;

namespace GeometryTowers.Map
{
    /// <summary>
    /// Handles initial creation of the tile map
    /// </summary>
    public class GameMapSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private Contexts _contexts;

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GeometryTowersTile);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGeometryTowersTile;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                Debug.Log(gameEntity.hasGeometryTowersTile);
            }
        }

        public GameMapSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            var entity = _contexts.game.CreateEntity();
            var dimensions = _contexts.configuration.gameMapConfiguration.value.Dimensions;

            entity.AddGeometryTowersMapGameMap(dimensions);

            // now create the tiles
            for (int x = 0; x < dimensions.y; x++)
            {
                for (int y = 0; y < dimensions.x; y++)
                {
                    _contexts.game.CreateTile(x, y);
                }
            }
        }
    }
}