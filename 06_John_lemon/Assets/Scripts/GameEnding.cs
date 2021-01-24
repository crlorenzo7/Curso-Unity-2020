using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 5f;
    // Start is called before the first frame update

    public CanvasGroup _canvasGroup;

    public GameObject _winScreen;
    public GameObject _loseScreen;

    public AudioSource _winSound;
    public AudioSource _gameOverSound;

    bool isPlayerOnExit;
    bool gameOver = false;
    bool isAudioPlayed = false;
    float timer = 0;

    private void Update()
    {
        if ((isPlayerOnExit || gameOver) && _canvasGroup.alpha < 1)
        {
            ShowEndScreen();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnExit = true;
            if (!isAudioPlayed)
            {
                isAudioPlayed = true;
                _winSound.Play();
            }
        }
    }

    private void ShowEndScreen()
    {
        timer += Time.deltaTime;
        _canvasGroup.alpha = timer / fadeDuration;
        if (_canvasGroup.alpha >= 1)
        {
            Application.Quit();
        }
    }

    public void GameOver()
    {
        _winScreen.SetActive(false);
        _loseScreen.SetActive(true);
        if (!isAudioPlayed)
        {
            isAudioPlayed = true;
            _gameOverSound.Play();
        }
        gameOver = true;
    }



}
