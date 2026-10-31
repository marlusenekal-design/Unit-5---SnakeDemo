using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public event Action<int> OnScoreChanged;

    public int Score { get; private set; }

    public void ResetScore()
    {
        Score = 0;
        NotifyScoreChanged();
    }

    public void AddPoint()
    {
        Score++;
        NotifyScoreChanged();
    }

    void NotifyScoreChanged()
    {
        if (OnScoreChanged != null)
        {
            OnScoreChanged(Score);
        }
    }
}