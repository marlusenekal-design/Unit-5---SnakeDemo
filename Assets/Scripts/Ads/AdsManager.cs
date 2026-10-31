using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public GameManager gameManager;
    public BannerAd bannerAd;
    public InterstitialAd interstitialAd;

    void OnEnable()
    {
        gameManager.OnPlayPressed += HandlePlayPressed;
        gameManager.OnGameStarted += HandleGameStarted;
        gameManager.OnMainMenuShown += HandleMainMenuShown;
    }

    void OnDisable()
    {
        gameManager.OnPlayPressed -= HandlePlayPressed;
        gameManager.OnGameStarted -= HandleGameStarted;
        gameManager.OnMainMenuShown -= HandleMainMenuShown;
    }

    void HandlePlayPressed()
    {
        interstitialAd.Show(gameManager.PlayFromMenu);
    }

    void HandleGameStarted()
    {
        bannerAd.Show();
    }

    void HandleMainMenuShown()
    {
        bannerAd.Hide();
    }
}