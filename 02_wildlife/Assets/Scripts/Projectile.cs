using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    public float fireForce = 50.0f;
    private bool pendingLaunch = true;
    private float destroyTime = 3f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (pendingLaunch)
        {
            Vector3 fireDirection = new Vector3(0f, 1f, 1f);
            rb.AddForce(fireForce * fireDirection, ForceMode.Impulse);
            Destroy(gameObject, destroyTime);
            pendingLaunch = false;
        }

    }


}
