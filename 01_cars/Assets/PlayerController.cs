using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(10.0f, 50f), SerializeField, Tooltip("velocidad del coche")]
    private float speed = 5.0f;

    public float turnSpeed = 5.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        Vector3 rotation = xMovement * turnSpeed * Time.deltaTime * Vector3.up;
        transform.Rotate(rotation);
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
