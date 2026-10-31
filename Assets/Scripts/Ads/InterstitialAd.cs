using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public AdsInitializer adsInitializer;
    public string placementId = "BP_Interstitial_Android";

    private bool isLoaded;
    private Action onFinished;

    void OnEnable()
    {
        adsInitializer.OnInitialized += Load;
    }

    void OnDisable()
    {
        adsInitializer.OnInitialized -= Load;
    }

    void Start()
    {
        if (adsInitializer.IsInitialized)
        {
            Load();
        }
    }

    void Load()
    {
        isLoaded = false;
        Advertisement.Load(placementId, this);
    }

    public void Show(Action finished)
    {
        if (onFinished != null)
        {
            return;
        }

        if (!isLoaded)
        {
            Debug.Log("Interstitial not ready, skipping");

            if (adsInitializer.IsInitialized)
            {
                Load();
            }

            finished();
            return;
        }

        onFinished = finished;
        isLoaded = false;
        Advertisement.Show(placementId, this);
    }

    void Finish()
    {
        Action callback = onFinished;
        onFinished = null;

        if (callback != null)
        {
            callback();
        }

        Load();
    }

    public void OnUnityAdsAdLoaded(string id)
    {
        isLoaded = true;
        Debug.Log("Interstitial loaded");
    }

    public void OnUnityAdsFailedToLoad(string id, UnityAdsLoadError error, string message)
    {
        Debug.Log("Interstitial failed to load: " + error + " - " + message);
    }

    public void OnUnityAdsShowFailure(string id, UnityAdsShowError error, string message)
    {
        Debug.Log("Interstitial failed to show: " + error + " - " + message);
        Finish();
    }

    public void OnUnityAdsShowStart(string id)
    {
    }

    public void OnUnityAdsShowClick(string id)
    {
    }

    public void OnUnityAdsShowComplete(string id, UnityAdsShowCompletionState state)
    {
        Finish();
    }
}