using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 40.0f;

    public float turnSpeed = 60f;

    public float elevationSpeed = 30f;

    public float wingsRestorationSpeed = 30f;

    GameObject _plane;

    // Start is called before the first frame update
    void Start()
    {
        _plane = GameObject.Find("PlaneModel");
    }

    // Update is called once per frame
    void Update()
    {
        float hInputValue = Input.GetAxis("Horizontal");
        float vInputValue = Input.GetAxis("Vertical");

        Vector3 translation = speed * Time.deltaTime * Vector3.forward;
        Vector3 horizontalRotation = turnSpeed * hInputValue * Time.deltaTime * Vector3.up;
        Vector3 wingRotation = wingsRestorationSpeed * hInputValue * Time.deltaTime * Vector3.forward;
        Vector3 verticalRotation = elevationSpeed * vInputValue * Time.deltaTime * Vector3.right;

        transform.Rotate(horizontalRotation + verticalRotation);
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        if (currentRotation.x > 45f && currentRotation.x < 180f)
        {
            currentRotation.x = 45f;
        }
        if (currentRotation.x < 315 && currentRotation.x > 180)
        {
            currentRotation.x = -45f;
        }
        transform.localEulerAngles = currentRotation;

        RotatePlane(hInputValue);
        if (Mathf.Approximately(hInputValue, 0) && Mathf.Approximately(vInputValue, 0))
        {
            RotateWings(horizontalRotation, hInputValue);
        }

        transform.Translate(translation);

    }

    private void RotateWings(Vector3 rotation, float inputValue)
    {

        Quaternion zRotation = Quaternion.Euler(_plane.transform.localEulerAngles.x, _plane.transform.localEulerAngles.y, 0);
        Quaternion xRotation = Quaternion.Euler(0, transform.localEulerAngles.y, transform.localEulerAngles.z);

        _plane.transform.localRotation = Quaternion.Slerp(_plane.transform.localRotation, zRotation, Time.deltaTime);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, xRotation, Time.deltaTime);

    }

    private void RotatePlane(float inputValue)
    {
        float multiplier = 1;
        if (inputValue > 0)
        {
            multiplier = -1;
        }
        if (inputValue != 0)
        {
            Quaternion zRotation = Quaternion.Euler(_plane.transform.localEulerAngles.x, _plane.transform.localEulerAngles.y, 30f * multiplier);
            _plane.transform.localRotation = Quaternion.Slerp(_plane.transform.localRotation, zRotation, Time.deltaTime);
        }
    }
}
