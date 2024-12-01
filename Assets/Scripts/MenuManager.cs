using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField NameInputField;
    public Text BestScoreText;

    private void Start()
    {
        UpdateBestScoreText();
    }

    public void StartGame()
    {
        string playerName = NameInputField.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            DataManager.Instance.PlayerName = playerName;
            SceneManager.LoadScene(1);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    private void UpdateBestScoreText()
    {
        if (DataManager.Instance != null && !string.IsNullOrEmpty(DataManager.Instance.HighScorePlayer))
        {
            BestScoreText.text = $"Best Score: {DataManager.Instance.HighScorePlayer} - {DataManager.Instance.HighScore}";
        }
        else
        {
            BestScoreText.text = "Best Score: None";
        }
    }
}