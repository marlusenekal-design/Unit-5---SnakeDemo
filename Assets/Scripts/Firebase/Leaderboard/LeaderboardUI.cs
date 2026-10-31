using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUI : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text listText;
    public Button openButton;
    public Button closeButton;
    public int entriesToShow = 10;

    void OnEnable()
    {
        openButton.onClick.AddListener(Open);
        closeButton.onClick.AddListener(Close);
    }

    void OnDisable()
    {
        openButton.onClick.RemoveListener(Open);
        closeButton.onClick.RemoveListener(Close);
    }

    void Start()
    {
        panel.SetActive(false);
    }

    async void Open()
    {
        panel.SetActive(true);
        listText.text = "Loading...";

        List<LeaderboardEntry> entries = await FirebaseDatabaseManager.Instance.GetTopScores(entriesToShow);

        if (entries.Count == 0)
        {
            listText.text = "No scores yet";
            return;
        }

        string text = "";

        for (int i = 0; i < entries.Count; i++)
        {
            text += (i + 1) + ". " + entries[i].name + " - " + entries[i].score + "\n";
        }

        listText.text = text;
    }

    void Close()
    {
        panel.SetActive(false);
    }
}