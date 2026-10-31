using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SnakeBody snakeBody;
    public SnakeMovement snakeMovement;
    public SnakeCollision snakeCollision;
    public SnakeEating snakeEating;
    public FoodSpawner foodSpawner;
    public ScoreManager scoreManager;
    public MainMenuUI mainMenuUI;
    public GameOverUI gameOverUI;

    public event Action OnPlayPressed;
    public event Action OnGameStarted;
    public event Action<int> OnGameOver;
    public event Action OnMainMenuShown;

    void OnEnable()
    {
        snakeCollision.OnDied += HandleDeath;
        snakeEating.OnAteFood += HandleFoodEaten;
        mainMenuUI.OnPlayClicked += HandlePlayClicked;
        gameOverUI.OnPlayAgainClicked += HandlePlayAgainClicked;
        gameOverUI.OnMenuClicked += HandleMenuClicked;
    }

    void OnDisable()
    {
        snakeCollision.OnDied -= HandleDeath;
        snakeEating.OnAteFood -= HandleFoodEaten;
        mainMenuUI.OnPlayClicked -= HandlePlayClicked;
        gameOverUI.OnPlayAgainClicked -= HandlePlayAgainClicked;
        gameOverUI.OnMenuClicked -= HandleMenuClicked;
    }

    void Start()
    {
        gameOverUI.Hide();
        ShowMainMenu();
    }

    public void StartGame()
    {
        snakeBody.ResetBody();
        scoreManager.ResetScore();
        foodSpawner.Spawn();
        snakeMovement.StartMoving();

        if (OnGameStarted != null)
        {
            OnGameStarted();
        }
    }

    public void PlayFromMenu()
    {
        mainMenuUI.Hide();
        StartGame();
    }

    void ShowMainMenu()
    {
        mainMenuUI.Show();

        if (OnMainMenuShown != null)
        {
            OnMainMenuShown();
        }
    }

    void HandlePlayClicked()
    {
        if (OnPlayPressed != null)
        {
            OnPlayPressed();
        }
        else
        {
            PlayFromMenu();
        }
    }

    void HandlePlayAgainClicked()
    {
        gameOverUI.Hide();
        StartGame();
    }

    void HandleMenuClicked()
    {
        gameOverUI.Hide();
        ShowMainMenu();
    }

    void HandleFoodEaten()
    {
        scoreManager.AddPoint();
        foodSpawner.Spawn();
    }

    void HandleDeath()
    {
        snakeMovement.Stop();
        gameOverUI.Show(scoreManager.Score);

        if (OnGameOver != null)
        {
            OnGameOver(scoreManager.Score);
        }
    }
}