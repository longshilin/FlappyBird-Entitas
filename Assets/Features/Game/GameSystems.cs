using GeometryTowers.Map;
using GeometryTowers.View;

namespace GeometryTowers.Game
{
    public sealed class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new GameMapSystem(contexts));
            Add(new ViewSystem(contexts));
        }
    }

}
