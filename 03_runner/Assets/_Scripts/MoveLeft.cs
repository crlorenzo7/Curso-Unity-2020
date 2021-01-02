using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update

    public float speedForce = 5f;

    private Rigidbody rb;
    private PlayerController _playerController;
    private SpawnManager _spawnManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_playerController.GameOver)
        {
            rb.velocity = new Vector3(-speedForce, rb.velocity.y, 0);
        }
    }
}
