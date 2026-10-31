using UnityEngine;

public class LeaderboardSubmitter : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerNameInput playerNameInput;

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
        FirebaseDatabaseManager.Instance.SaveScore(playerNameInput.PlayerName, score);
    }
}