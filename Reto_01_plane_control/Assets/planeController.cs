using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeController : MonoBehaviour
{
    // Start is called before the first frame update
    public float motorSpeed = 20f;
    public float horizontalRotSpeed = 0.5f;
    public float verticalRotSpeed = 1.5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = motorSpeed * transform.forward * Time.deltaTime;

        float hInputValue = Input.GetAxis("Horizontal");
        float vInputValue = Input.GetAxis("Vertical");

        Vector3 hRotVector = hInputValue * horizontalRotSpeed * Time.deltaTime * transform.right;
        Vector3 vRotVector = vInputValue * transform.up * verticalRotSpeed * Time.deltaTime;
        Vector3 direction = hRotVector + vRotVector;

        moveVector += direction;

        Vector3 rotationAngles = direction.normalized;

        transform.Rotate(Vector3.up, hInputValue * horizontalRotSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right, vInputValue * verticalRotSpeed * Time.deltaTime);
        transform.position += moveVector;
    }
}
