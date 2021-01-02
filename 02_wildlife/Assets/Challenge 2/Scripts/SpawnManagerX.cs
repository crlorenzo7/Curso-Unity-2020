using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    public float spawnInterval = 4.0f;
    public int roundsPerLevel = 5;
    public int maxLevel = 10;
    public List<float> probDistribution = new List<float>() { 0.5f, 0.4f, 0.1f };

    private float currentTime = 0f;
    [SerializeField]
    private float timeToWait;
    [SerializeField]
    private int level = 0;
    [SerializeField]
    private int rounds = 0;


    // Start is called before the first frame update
    void Start()
    {
        timeToWait = startDelay;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= timeToWait)
        {
            rounds++;
            if (rounds % roundsPerLevel == 0 && level < maxLevel)
            {
                level++;
            }
            SpawnRandomBall();
            currentTime = 0;
            timeToWait = spawnInterval - (level * 0.25f);
        }

    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        List<int> distribution = generateProbDistribution();
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        int distributionIndex = Random.Range(0, distribution.Count);
        int ballIndex = distribution[distributionIndex];
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }

    List<int> generateProbDistribution()
    {
        List<int> probIndexes = new List<int>();
        if (level == 3)
        {
            probDistribution = new List<float>() { 0.4f, 0.4f, 0.2f };
        }
        if (level == 6)
        {
            probDistribution = new List<float>() { 0.2f, 0.5f, 0.3f };
        }
        if (level == 8)
        {
            probDistribution = new List<float>() { 0.1f, 0.4f, 0.5f };
        }
        if (level == maxLevel)
        {
            probDistribution = new List<float>() { 0.05f, 0.35f, 0.6f };
        }

        for (int i = 0; i < probDistribution.Count; i++)
        {
            int numberOfIndexes = Mathf.FloorToInt(probDistribution[i] * 100);
            Debug.Log(numberOfIndexes);
            for (int j = 0; j < numberOfIndexes; j++)
            {
                probIndexes.Add(i);
            }
        }

        return probIndexes;

    }

}
