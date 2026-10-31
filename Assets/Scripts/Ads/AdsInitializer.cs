using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    public string androidGameId;
    public bool testMode = true;

    public event Action OnInitialized;

    public bool IsInitialized
    {
        get { return Advertisement.isInitialized; }
    }

    void Awake()
    {
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(androidGameId, testMode, this);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialized");

        if (OnInitialized != null)
        {
            OnInitialized();
        }
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Unity Ads failed to initialize: " + error + " - " + message);
    }
}