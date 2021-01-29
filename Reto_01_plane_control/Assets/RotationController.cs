using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float speed = 40.0f;

    public float turnSpeed = 60f;

    public GameObject _plane;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hInputValue = Input.GetAxis("Horizontal");
        float vInputValue = Input.GetAxis("Vertical");
        // Vector3 horizontalRotation = turnSpeed * hInputValue * Time.deltaTime * Vector3.forward;
        // Vector3 verticalRotation = elevationSpeed * vInputValue * Time.deltaTime * Vector3.right;


        //transform.rotation = Quaternion.LookRotation(_plane.transform.forward);


        if (Mathf.Abs(hInputValue) < 0.9f)
        {
            transform.Translate(speed * Time.deltaTime * _plane.transform.forward);
        }
        transform.Rotate(0f, turnSpeed * hInputValue * Time.deltaTime, 0f);

    }
}
