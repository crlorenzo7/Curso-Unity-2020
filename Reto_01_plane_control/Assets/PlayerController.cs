using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 40.0f;
    public float turnSpeed = 30.0f;
    public float elevationSpeed = 30.0f;
    public float wingsRotationSpeed = 50.0f;

    private bool rotating = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hInputValue = Input.GetAxis("Horizontal");
        float vInputValue = Input.GetAxis("Vertical");
        float wingsRotationValue = 0;
        if (Input.GetKey(KeyCode.Q))
        {
            wingsRotationValue = 1;
        }
        if (Input.GetKey(KeyCode.E))
        {
            wingsRotationValue = -1;
        }

        Vector3 forwardTranslation = speed * Time.deltaTime * Vector3.forward;
        Vector3 horizontalRotation = turnSpeed * hInputValue * Time.deltaTime * Vector3.up;
        Vector3 verticalRotation = elevationSpeed * vInputValue * Time.deltaTime * Vector3.right;
        Vector3 wingsRotation = wingsRotationValue * wingsRotationSpeed * Time.deltaTime * Vector3.forward;


        transform.Translate(forwardTranslation);
        transform.Rotate(horizontalRotation + verticalRotation + wingsRotation);

    }
}
