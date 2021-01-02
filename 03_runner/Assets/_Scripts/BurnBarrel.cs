using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnBarrel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fire;
    public Vector3 firePosition;

    void Start()
    {
        Vector3 position = transform.position;
        fire = Instantiate(fire, fire.transform.position, fire.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        Debug.Log(transform.position);
        fire.transform.position = new Vector3(position.x, firePosition.y, firePosition.z);
        Debug.Log("fire: " + fire.transform.position);
    }
}
