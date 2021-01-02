using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> obstacles;
    public Vector2 timeMultiplierRange = new Vector2(0.5f, 1f);
    public float timeMultiplier = 0.2f;

    [SerializeField]
    private float spawnInterval = 3f;
    [SerializeField]
    private float startDelay = 2f;
    [SerializeField]
    private int level = 0;
    private int maxLevel = 2;

    private float timeCounter = 0f;
    private float timeToWait;
    private Vector3 spawnerPosition;
    [SerializeField]
    private int obstacleRound = 0;
    private PlayerController _playerController;

    public int Level { get => level; set => level = value; }
    public int MaxLevel { get => maxLevel; }
    // Start is called before the first frame update
    void Start()
    {
        spawnerPosition = transform.position;
        timeToWait = startDelay;
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.GameOver)
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= timeToWait)
            {
                obstacleRound++;
                if (obstacleRound % 10 == 0 && level < maxLevel)
                {
                    level++;
                }
                generateNewObstacle();
                timeCounter = 0;
                timeToWait = (spawnInterval - level * timeMultiplier) * Random.Range(timeMultiplierRange.x, timeMultiplierRange.y);
            }
        }
    }

    void generateNewObstacle()
    {
        int index = Random.Range(0, obstacles.Count);
        GameObject obstacle = obstacles[index];
        Vector3 obstaclePosition = obstacle.transform.position;
        obstaclePosition.x = spawnerPosition.x;
        Instantiate(obstacle, obstaclePosition, obstacle.transform.rotation);

    }
}
