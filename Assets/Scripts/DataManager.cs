using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string PlayerName;
    public int HighScore;
    public string HighScorePlayer;

    private string saveFilePath;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        saveFilePath = Application.persistentDataPath + "/savefile.json";

        LoadGameData();
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData
        {
            HighScore = HighScore,
            HighScorePlayer = HighScorePlayer
        };

        File.WriteAllText(saveFilePath, JsonUtility.ToJson(data));
    }

    public void LoadGameData()
    {
        if (File.Exists(saveFilePath))
        {
            SaveData data = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveFilePath));
            HighScore = data.HighScore;
            HighScorePlayer = data.HighScorePlayer;
        }
    }

    [System.Serializable]
    private class SaveData
    {
        public int HighScore;
        public string HighScorePlayer;
    }
}
