using GeometryTowers.Map;

namespace GeometryTowers.Game
{
    public sealed class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new GameMapSystem(contexts));
        }
    }

}
