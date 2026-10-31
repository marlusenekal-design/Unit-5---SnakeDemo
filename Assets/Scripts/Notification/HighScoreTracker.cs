using System;
using UnityEngine;

public class HighScoreTracker : MonoBehaviour
{
    public GameManager gameManager;

    public event Action<int> OnNewHighScore;

    private const string HighScoreKey = "HighScore";

    void OnEnable()
    {
        gameManager.OnGameOver += HandleGameOver;
    }

    void OnDisable()
    {
        gameManager.OnGameOver -= HandleGameOver;
    }

    void HandleGameOver(int score)
    {
        int highScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if (score <= highScore)
        {
            return;
        }

        PlayerPrefs.SetInt(HighScoreKey, score);
        PlayerPrefs.Save();

        if (highScore > 0 && OnNewHighScore != null)
        {
            OnNewHighScore(score);
        }
    }
}