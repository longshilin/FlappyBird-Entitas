using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays the current high score in a text label
/// </summary>
public class HighScoreLabel : MonoBehaviour, IAnyScoreListener
{
    private Text _label;

    private void Start()
    {
        _label = GetComponent<Text>();

        var contexts = Contexts.sharedInstance;
        var e = contexts.game.CreateEntity();
        e.AddAnyScoreListener(this);

        // set the initial value
        OnAnyScore(null, 0);
    }

    public void OnAnyScore(GameEntity entity, int value)
    {
        var highScore = PlayerPrefs.GetInt("HighScore", 0);

        _label.text = (value > highScore ? value : highScore).ToString();
    }
}