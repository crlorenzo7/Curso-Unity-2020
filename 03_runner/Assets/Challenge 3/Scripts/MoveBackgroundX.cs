using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundX : MonoBehaviour
{
    public float speed = 5f;
    private PlayerControllerX _playerController;

    void Start()
    {
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.GameOver)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        }
    }
}
