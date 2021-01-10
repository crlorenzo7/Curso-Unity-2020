using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum GameState { IDLE, PLAYING, PAUSE, GAMEOVER }

public class GameManager : MonoBehaviour
{

    GameMode gameMode = GameMode.EASY();
    GameState gameState = GameState.IDLE;
    CanvasManager _canvasManager;

    int numberOfLifes = 3;

    const int MIN_SCORE = 0;
    const int MAX_SCORE = 99999;

    private int score = 0;
    private float gameTime = 0f;

    private float startDelay = 2f;
    public float xRange = 5f;
    public float zRotationMaxAngle = 30f;

    public List<GameObject> prefabs = new List<GameObject>();

    Vector3 spawnPosition;

    public int Score { get => score; set => score = Mathf.Clamp(value, MIN_SCORE, MAX_SCORE); }
    public float GameTime { get => gameTime; set => gameTime = value; }
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

        while (GameState == GameState.PLAYING)
        {
            int numberOfObjectsToSpawn = Random.Range(gameMode.MinObjectsPerWave, gameMode.MaxObjetcsPerWave);
            for (int i = 0; i < numberOfObjectsToSpawn; i++)
            {
                float xPosition = Random.Range(-xRange, xRange);
                Vector3 position = xPosition * Vector3.right;

                float zRotation = Random.Range(0f, zRotationMaxAngle) * (xPosition / Mathf.Abs(xPosition));
                Quaternion rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);

                int prefabIndex = Random.Range(0, prefabs.Count);

                Instantiate(prefabs[prefabIndex], position, rotation);
            }
            yield return new WaitForSeconds(gameMode.SpawnInterval);
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

    public void SetGameMode(int index)
    {
        this.gameMode = GameMode.GetByIndex(index);
        this.numberOfLifes = this.gameMode.NumberOfLifes;
    }

    public void StartGame()
    {
        GameState = GameState.PLAYING;
        _canvasManager.HideMainMenuScreen();
        _canvasManager.ShowPlayingPanel();
        StartCoroutine(Spawn());
    }

    public void UpdateNumberOfLifes(int number)
    {
        this.numberOfLifes += number;
        if (this.numberOfLifes == 0)
        {
            FinishGame();
        }
    }
}
