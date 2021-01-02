using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speedForce = 5f;
    // Start is called before the first frame update
    private GameObject player;
    Rigidbody _rb;
    bool grounded = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (grounded)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Vector3 vForce = speedForce * direction;

            _rb.AddForce(vForce, ForceMode.Force);
        }

    }

    private void Update()
    {
        if (transform.position.y < -1f)
        {
            grounded = false;
            Destroy(gameObject, 2f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
