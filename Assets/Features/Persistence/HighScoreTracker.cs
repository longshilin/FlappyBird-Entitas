using UnityEngine;

/// <summary>
/// Updates the PlayerPrefs with the highest score
/// </summary>
public class HighScoreTracker : MonoBehaviour, IAnyScoreListener
{
    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        var e = contexts.game.CreateEntity();
        e.AddAnyScoreListener(this);
    }


    public void OnAnyScore(GameEntity entity, int value)
    {
        var highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (value > highScore)
        {
            PlayerPrefs.SetInt("HighScore", value);
            PlayerPrefs.Save();
        }
    }
}