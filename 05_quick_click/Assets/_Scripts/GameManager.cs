using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum Difficulty { EASY, MEDIUM, HARD }

[System.Serializable]
public enum GameState { IDLE, PLAYING, PAUSE, GAMEOVER }

public class GameManager : MonoBehaviour
{

    Difficulty difficulty = Difficulty.MEDIUM;
    GameState gameState = GameState.IDLE;

    CanvasManager _canvasManager;
    const int MIN_SCORE = 0;
    const int MAX_SCORE = 99999;
    private int score = 0;
    private float gameTime = 0f;
    bool gameOver = false;

    private float startDelay = 2f;
    public float spawnInterval = 2f;
    public float xRange = 5f;
    public float zRotationMaxAngle = 30f;

    public List<GameObject> prefabs = new List<GameObject>();

    Vector3 spawnPosition;

    public int Score { get => score; set => score = Mathf.Clamp(value, MIN_SCORE, MAX_SCORE); }
    public float GameTime { get => gameTime; set => gameTime = value; }
    public bool GameOver { get => gameOver; set => gameOver = value; }
    public GameState GameState { get => gameState; set => gameState = value; }

    // Start is called before the first frame update
    void Start()
    {
        _canvasManager = FindObjectOfType<CanvasManager>();
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState == GameState.PLAYING)
        {
            GameTime += Time.deltaTime;
            _canvasManager.UpdatePlayingCanvas();
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(startDelay);

        int zPosition = 0;
        while (GameState == GameState.PLAYING)
        {
            float xPosition = Random.Range(-xRange, xRange);
            Vector3 position = xPosition * Vector3.right;
            position.z = -((zPosition % 8) + 1);
            zPosition += 2;

            float zRotation = Random.Range(0f, zRotationMaxAngle) * (xPosition / Mathf.Abs(xPosition));
            Quaternion rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);

            int prefabIndex = Random.Range(0, prefabs.Count);

            Instantiate(prefabs[prefabIndex], position, rotation);
            yield return new WaitForSeconds(spawnInterval);
        }

    }

    public void UpdateScore(int points)
    {
        Score += points;
    }

    public void FinishGame()
    {
        gameState = GameState.GAMEOVER;
        _canvasManager.ShowGameOverScreen();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetDifficulty(int difficulty)
    {
        this.difficulty = (Difficulty)difficulty;
        Debug.Log(this.difficulty);
    }

    public void StartGame()
    {
        GameState = GameState.PLAYING;
        _canvasManager.HideMainMenuScreen();
        _canvasManager.ShowPlayingPanel();
        StartCoroutine(Spawn());
    }
}
