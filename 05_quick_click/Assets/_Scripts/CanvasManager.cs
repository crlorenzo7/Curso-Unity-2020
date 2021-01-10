using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{

    GameManager _gameManager;

    TMP_Text scoreText;
    TMP_Text timeText;
    TextMeshProUGUI gameOverText;
    GameObject gameOverMenu;
    GameObject mainMenu;
    GameObject playingPanel;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        timeText = GameObject.Find("TimeText").GetComponent<TMP_Text>();
        gameOverMenu = GameObject.Find("GameOverMenu");
        mainMenu = GameObject.Find("MainMenu");
        playingPanel = GameObject.Find("PlayingPanel");
        playingPanel.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    public void UpdatePlayingCanvas()
    {
        scoreText.GetComponent<TMP_Text>().SetText("Puntuacion: " + _gameManager.Score);
        timeText.GetComponent<TMP_Text>().SetText(FormatTime(_gameManager.GameTime));
    }

    public void ShowGameOverScreen()
    {
        gameOverMenu.SetActive(true);
    }

    public void ShowPlayingPanel()
    {
        playingPanel.SetActive(true);
    }

    public void HideMainMenuScreen()
    {
        mainMenu.SetActive(false);
    }

    private string FormatTime(float time)
    {
        int timeInSeconds = (int)time;
        int minutes = timeInSeconds / 60;
        int seconds = timeInSeconds % 60;
        return FormatNumberForTime(minutes) + ":" + FormatNumberForTime(seconds);
    }

    private string FormatNumberForTime(int number)
    {
        if (number < 10)
        {
            return "0" + number;
        }
        return "" + number;
    }
}
