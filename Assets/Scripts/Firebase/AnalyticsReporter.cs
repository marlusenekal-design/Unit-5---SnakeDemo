using UnityEngine;

public class AnalyticsReporter : MonoBehaviour
{
    public GameManager gameManager;

    void OnEnable()
    {
        gameManager.OnGameStarted += HandleGameStarted;
        gameManager.OnGameOver += HandleGameOver;
    }

    void OnDisable()
    {
        gameManager.OnGameStarted -= HandleGameStarted;
        gameManager.OnGameOver -= HandleGameOver;
    }

    void HandleGameStarted()
    {
        FirebaseManager.Instance.FirebaseEvent_GameStart();
    }

    void HandleGameOver(int score)
    {
        FirebaseManager.Instance.FirebaseEvent_GameOver(score);
    }
}