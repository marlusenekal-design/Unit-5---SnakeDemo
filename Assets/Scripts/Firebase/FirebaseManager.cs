using UnityEngine;
using Firebase;
using Firebase.Analytics;

public class FirebaseManager : MonoBehaviour
{
    public static FirebaseManager Instance;

    private bool firebaseReady = false;

    public bool FirebaseReady
    {
        get { return firebaseReady; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(this);
        }
    }

    private async void Start()
    {
        var status = await FirebaseApp.CheckAndFixDependenciesAsync();

        if (status == DependencyStatus.Available)
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;

            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

            firebaseReady = true;
            Debug.Log("Firebase Analytics Initialized");
        }

        else
        {
            Debug.Log($"Firebase initialization failed: {status}");
        }
    }

    #region Analytics Events

    public void FirebaseEvent_GameStart()
    {
        if (!firebaseReady)
            return;

        FirebaseAnalytics.LogEvent("game_start");
        Debug.Log("Game Start Event Complete!");
    }

    public void FirebaseEvent_GameOver(int score)
    {
        if (!firebaseReady)
            return;

        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventPostScore, FirebaseAnalytics.ParameterScore, score);
        Debug.Log("Game Over Event Complete!");
    }

    #endregion
}