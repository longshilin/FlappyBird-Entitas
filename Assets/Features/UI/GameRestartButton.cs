using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameRestartButton : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        if (_button != null)
        {
            _button.onClick.AddListener(OnGameRestartButton);
        }
    }

    private void OnGameRestartButton()
    {
        var contexts = Contexts.sharedInstance;
        contexts.game.isGameRestarted = true;
    }
}