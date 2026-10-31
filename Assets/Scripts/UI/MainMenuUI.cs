using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject panel;
    public Button playButton;

    public event Action OnPlayClicked;

    void OnEnable()
    {
        playButton.onClick.AddListener(HandlePlayClicked);
    }

    void OnDisable()
    {
        playButton.onClick.RemoveListener(HandlePlayClicked);
    }

    void HandlePlayClicked()
    {
        if (OnPlayClicked != null)
        {
            OnPlayClicked();
        }
    }

    public void Show()
    {
        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}