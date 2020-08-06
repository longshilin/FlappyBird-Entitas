using GeometryTowers.Configuration;
using UnityEngine;

namespace GeometryTowers.Assets.Features.Game
{
    public class GameControllerBehaviour : MonoBehaviour
    {
        public GameMapConfiguration gameMapConfiguration;

        GameController _gameController;

        void Awake() => _gameController = new GameController(Contexts.sharedInstance, gameMapConfiguration);
        void Start() => _gameController.Initialize();
        void Update() => _gameController.Execute();
    }
}
