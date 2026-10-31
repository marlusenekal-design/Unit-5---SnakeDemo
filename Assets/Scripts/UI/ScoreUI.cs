using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TMP_Text scoreText;

    void OnEnable()
    {
        scoreManager.OnScoreChanged += UpdateText;
    }

    void OnDisable()
    {
        scoreManager.OnScoreChanged -= UpdateText;
    }

    void UpdateText(int score)
    {
        scoreText.text = "Score: " + score;
    }
}