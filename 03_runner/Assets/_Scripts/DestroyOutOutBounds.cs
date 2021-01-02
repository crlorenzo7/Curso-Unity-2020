using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOutBounds : MonoBehaviour
{
    // Start is called before the first frame update

    float xBound = -5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xBound)
        {
            Destroy(gameObject);
        }
    }
}
