using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text finalScoreText;
    public Button playAgainButton;
    public Button menuButton;

    public event Action OnPlayAgainClicked;
    public event Action OnMenuClicked;

    void OnEnable()
    {
        playAgainButton.onClick.AddListener(HandlePlayAgainClicked);
        menuButton.onClick.AddListener(HandleMenuClicked);
    }

    void OnDisable()
    {
        playAgainButton.onClick.RemoveListener(HandlePlayAgainClicked);
        menuButton.onClick.RemoveListener(HandleMenuClicked);
    }

    void HandlePlayAgainClicked()
    {
        if (OnPlayAgainClicked != null)
        {
            OnPlayAgainClicked();
        }
    }

    void HandleMenuClicked()
    {
        if (OnMenuClicked != null)
        {
            OnMenuClicked();
        }
    }

    public void Show(int score)
    {
        finalScoreText.text = "Score: " + score;
        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}