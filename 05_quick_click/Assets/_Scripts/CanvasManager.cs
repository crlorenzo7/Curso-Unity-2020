﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{

    GameManager _gameManager;

    TMP_Text scoreText;
    TMP_Text timeText;
    TMP_Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        timeText = GameObject.Find("TimeText").GetComponent<TMP_Text>();
        gameOverText = GameObject.Find("GameOverText").GetComponent<TMP_Text>();
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (_gameManager.GameOver)
        {
            gameOverText.enabled = true;
        }
        else
        {
            scoreText.GetComponent<TMP_Text>().SetText("Puntuacion: " + _gameManager.Score);
            timeText.GetComponent<TMP_Text>().SetText(FormatTime(_gameManager.GameTime));
        }
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
