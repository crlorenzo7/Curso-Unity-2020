using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public float jumpForce = 30f;
    Rigidbody _rb;
    Vector3 gravity;
    bool grounded = true;
    GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Origin");
        gravity = Physics.gravity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 finalVelocity = _rb.velocity;
        float vValue = Input.GetAxis("Vertical");

        if (grounded)
        {
            finalVelocity = (vValue * speed * focalPoint.transform.forward) + gravity;
            if (Input.GetKey(KeyCode.Space))
            {
                _rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
                finalVelocity.y = _rb.velocity.y;
                grounded = false;
            }

        }
        if (!insideBounds())
        {
            _rb.velocity = Vector3.zero;
        }
        else
        {

            _rb.velocity = finalVelocity;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private bool insideBounds()
    {

        Vector3 position = transform.position;

        if (!checkAxisBounds(position.x, _rb.velocity.x))
        {
            position.x = _rb.velocity.x >= 0 ? 19f : -19f;
            transform.position = position;
            return false;
        }

        if (!checkAxisBounds(position.z, _rb.velocity.z))
        {
            position.z = _rb.velocity.z >= 0 ? 19f : -19f;
            transform.position = position;
            return false;
        }

        return true;

    }

    private bool checkAxisBounds(float axisPosition, float axisVelocity)
    {
        if (axisPosition >= 20 && axisVelocity >= 0)
        {
            return false;
        }

        if (axisPosition <= -20f && axisVelocity <= 0)
        {
            return false;
        }
        return true;
    }
}
