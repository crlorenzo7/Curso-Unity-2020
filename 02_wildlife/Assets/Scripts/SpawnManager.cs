using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public float spawnInterval = 0.3f;
    public int roundsPerLevel = 5;
    public float spawnMargin = 1f;

    public int level = 1;
    private int rounds = 0;
    private float spawnZPosition;
    private Vector2 spawnRange;
    // Start is called before the first frame update
    void Start()
    {
        GameObject screenObjectController = GameObject.FindGameObjectWithTag("ScreenController");
        GameDimension dimensions = screenObjectController.GetComponent<ScreenController>().dimensions;
        spawnZPosition = transform.position.z;

        spawnRange = new Vector2(dimensions.MinH + spawnMargin, dimensions.MaxH - spawnMargin);
        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }

    // Update is called once per frame
    void SpawnEnemies()
    {
        float xValue = Random.Range(spawnRange.x, spawnRange.y);
        Vector3 position = new Vector3(xValue, 0f, spawnZPosition);

        int enemyIndex = Random.Range(0, enemies.Count);
        GameObject enemy = enemies[enemyIndex];

        Instantiate(enemy, position, enemy.transform.rotation);

        rounds++;
        if (rounds == roundsPerLevel)
        {
            level++;
            rounds = 0;
        }
    }

}
