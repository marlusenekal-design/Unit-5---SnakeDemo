using System;
using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public static class AndroidNotifications
{
    private const string ChannelId = "snake_channel";

    public static void Setup()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Id = ChannelId,
            Name = "Snake Notifications",
            Importance = Importance.High,
            Description = "High scores and reminders",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        // Android 13 and newer needs the player's permission to show notifications
        new PermissionRequest();
#else
        Debug.Log("Notifications set up");
#endif
    }

    public static void SendNow(string title, string text)
    {
        Schedule(title, text, DateTime.Now);
    }

    public static void Schedule(string title, string text, DateTime fireTime)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidNotification notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = fireTime;

        AndroidNotificationCenter.SendNotification(notification, ChannelId);
#else
        Debug.Log("Notification at " + fireTime + ": " + title + " - " + text);
#endif
    }

    public static void CancelScheduled()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidNotificationCenter.CancelAllScheduledNotifications();
#else
        Debug.Log("Scheduled notifications cancelled");
#endif
    }
}