using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutScreen : MonoBehaviour
{
    // Start is called before the first frame update
    private float topBound;
    private float bottomBound;
    private float leftBound;
    private float rightBound;

    void Start()
    {
        GameObject gameObjectScreen = GameObject.FindGameObjectWithTag("ScreenController");
        ScreenController screenController = gameObjectScreen.GetComponent<ScreenController>();

        topBound = screenController.dimensions.MaxV + screenController.dimensions.toleranceZoneLength;
        bottomBound = screenController.dimensions.MinV - screenController.dimensions.toleranceZoneLength;
        leftBound = screenController.dimensions.MinH - screenController.dimensions.toleranceZoneLength;
        rightBound = screenController.dimensions.MaxH + screenController.dimensions.toleranceZoneLength;
    }

    // Update is called once per frame
    void Update()
    {

        if (isOutOfBounds())
        {
            if (gameObject.CompareTag("enemy"))
            {
                Debug.Log("GAME OVER");
                Time.timeScale = 0;
            }
            Destroy(gameObject);
        }
    }

    bool isOutOfBounds()
    {
        if (transform.position.z < bottomBound || transform.position.z > topBound)
        {
            return true;
        }
        if (transform.position.x < leftBound || transform.position.x > rightBound)
        {
            return true;
        }

        return false;
    }
}
