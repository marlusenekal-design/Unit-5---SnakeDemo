using System;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public HighScoreTracker highScoreTracker;
    public float inactiveMinutes = 1440f;

    void OnEnable()
    {
        highScoreTracker.OnNewHighScore += HandleNewHighScore;
    }

    void OnDisable()
    {
        highScoreTracker.OnNewHighScore -= HandleNewHighScore;
    }

    void Start()
    {
        AndroidNotifications.Setup();

        AndroidNotifications.CancelScheduled();
    }

    void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            ScheduleInactiveReminder();
        }
        else
        {
            AndroidNotifications.CancelScheduled();
        }
    }

    void ScheduleInactiveReminder()
    {
        AndroidNotifications.CancelScheduled();

        AndroidNotifications.Schedule(
            "Your snake misses you!",
            "Come back and snake your drain",
            DateTime.Now.AddMinutes(inactiveMinutes));
    }

    void HandleNewHighScore(int score)
    {
        AndroidNotifications.SendNow("New High Score!", "You set a new personal best of " + score + "!");
    }
}