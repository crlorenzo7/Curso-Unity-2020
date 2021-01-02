using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    //OPCIONES DE TIRO
    public float timeBetweenFires = 0.5f;
    private float nextFireTime = 0.0f;
    private float currentTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentTime > nextFireTime)
            {
                nextFireTime = currentTime + timeBetweenFires;

                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

                nextFireTime -= currentTime;
                currentTime = 0f;
            }
        }
    }
}
