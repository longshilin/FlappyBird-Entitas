using UnityEngine;

namespace Entidades
{
    public class GameMapInitializer : MonoBehaviour
    {
        private void Start()
        {
            var contexts = new Contexts();

            var e = contexts.game.CreateEntity();

            var c = e.CreateComponent<TileComponent>(0);
        }
    }
}
