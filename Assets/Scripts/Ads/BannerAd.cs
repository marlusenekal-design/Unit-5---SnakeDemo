using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{
    public AdsInitializer adsInitializer;
    public string placementId = "BP_Banner_Android";
    public BannerPosition position = BannerPosition.TOP_CENTER;

    private bool loadRequested;
    private bool isLoaded;
    private bool wantsToShow;

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
        if (loadRequested)
        {
            return;
        }

        loadRequested = true;

        Advertisement.Banner.SetPosition(position);

        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.Load(placementId, options);
    }

    void OnBannerLoaded()
    {
        isLoaded = true;
        Debug.Log("Banner loaded");

        if (wantsToShow)
        {
            Advertisement.Banner.Show(placementId);
        }
    }

    void OnBannerError(string message)
    {
        loadRequested = false;
        Debug.Log("Banner failed to load: " + message);
    }

    public void Show()
    {
        wantsToShow = true;

        if (isLoaded)
        {
            Advertisement.Banner.Show(placementId);
        }
    }

    public void Hide()
    {
        wantsToShow = false;

        if (isLoaded)
        {
            Advertisement.Banner.Hide();
        }
    }
}