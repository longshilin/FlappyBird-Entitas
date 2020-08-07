using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameCloseButton : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        if (_button != null)
        {
            _button.onClick.AddListener(OnGameCloseButtonClicked);
        }
    }

    private void OnGameCloseButtonClicked()
    {
        // just for testing sake, iOS doesn't like forceful quitting
        Application.Quit();
    }
}