using UnityEngine;
using Zenject.Asteroids;

public class GameControllerBehaviour : MonoBehaviour
{
    GameController _gameController;

    void Awake() => _gameController = new GameController(Contexts.sharedInstance);
    void Start() => _gameController.Initialize();
    void Update() => _gameController.Execute();
}
