using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] powerUps;

    private float spawnRange = 9;
    public int enemiesInWave = 5;
    public int level = 0;

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("EnemyN1").Length == 0)
        {
            SpawnEnemyWave();
        }
    }

    void SpawnEnemyWave()
    {
        level++;
        for (int i = 0; i < enemiesInWave * level; i++)
        {
            int prefabIndex = Random.Range(0, enemies.Length);
            GameObject prefab = enemies[prefabIndex];

            Instantiate(prefab, GetSpawnPosition(), prefab.transform.rotation);
        }

        SpawnPowerUps();
    }

    ///<summary>Genera un PowerUp en una posicion aleatoria pantalla</summary>
    ///<param name="prefabs">Lista de powerUps</param>
    void SpawnPowerUps()
    {


        GameObject powerUp = GameObject.FindWithTag("PowerUp");
        if (powerUp != null)
        {
            Destroy(powerUp);
        }

        int prefabIndex = Random.Range(0, powerUps.Length);
        GameObject prefab = powerUps[prefabIndex];

        Instantiate(prefab, GetSpawnPosition(), prefab.transform.rotation);


    }

    ///<summary>Genera una posicion aleatoria para situar un objeto en pantalla</summary>
    ///<returns>Devuelve una posicion valida dentro del campo de juego</returns>
    Vector3 GetSpawnPosition()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new Vector3(spawnX, 0, spawnZ);

        return spawnPosition;
    }
}
