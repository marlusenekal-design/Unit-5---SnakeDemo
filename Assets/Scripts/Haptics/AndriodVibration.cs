using UnityEngine;

public static class AndroidVibration
{
    public static void Vibrate(long milliseconds)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        using (AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
        using (AndroidJavaObject vibrator = activity.Call<AndroidJavaObject>("getSystemService", "vibrator"))
        {
            vibrator.Call("vibrate", milliseconds);
        }
#else
        Debug.Log("Vibrate for " + milliseconds + "ms");
#endif
    }

#if UNITY_ANDROID
    static void AddVibratePermission()
    {
        Handheld.Vibrate();
    }
#endif
}