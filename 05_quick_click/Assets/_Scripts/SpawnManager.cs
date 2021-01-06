using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private float startDelay = 2f;
    public float spawnInterval = 2f;
    public float xRange = 5f;
    public float zRotationMaxAngle = 30f;

    public GameObject[] prefabs;

    bool gameOver = false;
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(startDelay);

        int zPosition = 0;
        while (!gameOver)
        {
            float xPosition = Random.Range(-xRange, xRange);
            Vector3 position = xPosition * Vector3.right;
            position.z = -((zPosition % 8) + 1);
            zPosition += 2;

            float zRotation = Random.Range(0f, zRotationMaxAngle) * (xPosition / Mathf.Abs(xPosition));
            Quaternion rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);

            int prefabIndex = Random.Range(0, prefabs.Length);

            Instantiate(prefabs[prefabIndex], position, rotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
