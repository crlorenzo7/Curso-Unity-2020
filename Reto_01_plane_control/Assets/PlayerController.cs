using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 40.0f;

    public float turnSpeed = 60f;

    public float elevationSpeed = 30f;

    public float wingSpeed = 30f;

    public float wingsRestorationSpeed = 30f;

    public float xRotationRange = 30f;
    public float zRotationRange = 90f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float hInputValue = Input.GetAxis("Horizontal");
        float vInputValue = Input.GetAxis("Vertical");

        Vector3 verticalRotation = elevationSpeed * vInputValue * Time.deltaTime * Vector3.right;
        Vector3 horizontalRotation = turnSpeed * hInputValue * Vector3.up * Time.deltaTime;
        //RotatePlaneWings(-wingSpeed * hInputValue * Time.deltaTime);

        // if (Mathf.Abs(hInputValue) < 0.9f)
        // {
        //     RotatePlaneVertically(elevationSpeed * vInputValue * Time.deltaTime);
        // }

        // if (Mathf.Abs(hInputValue) == 0 && transform.eulerAngles.z != 0)
        // {
        //     RotateWingsToZero();
        // }
        transform.Rotate(horizontalRotation);
        transform.Rotate(verticalRotation);
        transform.Translate(speed * Vector3.forward * Time.deltaTime);

    }

    protected void LateUpdate()
    {
        Debug.Log("rotation: " + transform.rotation);
        Debug.Log("Euler: " + transform.eulerAngles);
        Debug.Log("next: " + Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f), 180f);

    }

    void RotateWingsToZero()
    {
        Vector3 currentEulerAngles = transform.eulerAngles;

        float restorationSpeed = wingSpeed;
        if (transform.eulerAngles.z <= 90f)
        {
            restorationSpeed = -wingSpeed;
        }

        float zRotation = restorationSpeed * Time.deltaTime;
        float currentZValue = currentEulerAngles.z + zRotation;

        if (currentZValue < 1f || currentZValue > 359f)
        {
            currentEulerAngles.z = 0f;
            transform.eulerAngles = currentEulerAngles;
        }
        else
        {

            transform.Rotate(0f, 0f, zRotation);
        }
    }

    void RotatePlaneWings(float zRotation)
    {
        Vector3 currentEulerAngles = transform.eulerAngles;
        float currentZValue = currentEulerAngles.z + zRotation;

        if (currentZValue >= 90f && currentZValue <= 270f)
        {
            if (currentZValue > 90 && currentZValue < 100)
            {
                currentEulerAngles.z = 90f;
                currentEulerAngles.y = 0f;
                transform.eulerAngles = currentEulerAngles;
            }
            if (currentZValue > 260f && currentZValue < 270f)
            {
                currentEulerAngles.z = 270f;
                currentEulerAngles.y = 0f;
                transform.eulerAngles = currentEulerAngles;
            }
        }
        else
        {
            transform.Rotate(0f, 0f, zRotation);
        }
    }

    void RotatePlaneVertically(float xRotation)
    {
        Vector3 currentEulerAngles = transform.localEulerAngles;
        float currentZValue = currentEulerAngles.x + xRotation;

        if (currentZValue >= 30f && currentZValue <= 330f)
        {
            if (currentZValue > 30 && currentZValue < 40)
            {
                currentEulerAngles.x = 30f;
                currentEulerAngles.y = 0f;
                transform.eulerAngles = currentEulerAngles;
            }
            if (currentZValue > 320f && currentZValue < 330f)
            {
                currentEulerAngles.x = 330f;
                currentEulerAngles.y = 0f;
                transform.eulerAngles = currentEulerAngles;
            }
        }
        else
        {
            transform.Rotate(xRotation * transform.right);
        }
    }

    bool isAngleOutOfRange(float range, float currentAngle, float rotation, out float angle, float margin = 10f)
    {

        angle = currentAngle + rotation;

        float upperLimit = 360 - range;

        if (angle >= range && angle <= upperLimit)
        {
            if (angle > range && angle < angle + margin)
            {
                angle = range;
                return true;
            }
            if (angle > upperLimit - margin && angle < upperLimit)
            {
                angle = upperLimit;
                return true;
            }
        }
        return false;
    }
}
