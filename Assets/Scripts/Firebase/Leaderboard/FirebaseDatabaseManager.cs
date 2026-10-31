using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Firebase.Database;

public class FirebaseDatabaseManager : MonoBehaviour
{
    public static FirebaseDatabaseManager Instance;

    private DatabaseReference database;
    private string playerId;

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

        playerId = SystemInfo.deviceUniqueIdentifier;
    }

    private void SetupDatabase()
    {
        if (database == null)
        {
            database = FirebaseDatabase.DefaultInstance.RootReference;
        }
    }

    #region Realtime Database

    public async void SaveScore(string playerName, int score)
    {
        if (!FirebaseManager.Instance.FirebaseReady)
            return;

        SetupDatabase();

        try
        {
            DataSnapshot snapshot = await database.Child("leaderboard").Child(playerId).Child("score").GetValueAsync();

            int bestScore = 0;

            if (snapshot.Exists)
            {
                bestScore = Convert.ToInt32(snapshot.Value);
            }

            await database.Child("leaderboard").Child(playerId).Child("name").SetValueAsync(playerName);

            if (!snapshot.Exists || score > bestScore)
            {
                await database.Child("leaderboard").Child(playerId).Child("score").SetValueAsync(score);
                Debug.Log($"New best score saved: {score}");
            }

            else
            {
                Debug.Log($"Score {score} did not beat best of {bestScore}");
            }
        }

        catch (Exception e)
        {
            Debug.Log($"Failed to save score: {e.Message}");
        }
    }

    public async Task<List<LeaderboardEntry>> GetTopScores(int count)
    {
        List<LeaderboardEntry> entries = new List<LeaderboardEntry>();

        if (!FirebaseManager.Instance.FirebaseReady)
            return entries;

        SetupDatabase();

        try
        {
            DataSnapshot snapshot = await database.Child("leaderboard").OrderByChild("score").LimitToLast(count).GetValueAsync();

            foreach (DataSnapshot player in snapshot.Children)
            {
                if (!player.Child("score").Exists)
                    continue;

                string name = "Player";

                if (player.Child("name").Exists)
                {
                    name = player.Child("name").Value.ToString();
                }

                int score = Convert.ToInt32(player.Child("score").Value);
                entries.Add(new LeaderboardEntry(name, score));
            }

            entries.Reverse();
        }

        catch (Exception e)
        {
            Debug.Log($"Failed to load leaderboard: {e.Message}");
        }

        return entries;
    }

    #endregion
}