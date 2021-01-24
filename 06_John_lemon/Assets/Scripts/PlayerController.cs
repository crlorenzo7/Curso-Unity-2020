using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 20f;
    Rigidbody _rigidbody;
    Animator _animator;
    AudioSource _footSteps;

    Vector3 movement;
    Quaternion rotation = Quaternion.identity;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _footSteps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool existsMovement = vertical != 0 || horizontal != 0;

        if (existsMovement)
        {
            if (!_footSteps.isPlaying)
            {
                _footSteps.Play();
            }
        }
        else
        {
            _footSteps.Stop();
        }
        _animator.SetBool("isWalking", existsMovement);

        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        Vector3 newForward = Vector3.RotateTowards(transform.forward, movement, rotationSpeed * Time.fixedDeltaTime, 0f);
        rotation = Quaternion.LookRotation(newForward);


    }

    private void OnAnimatorMove()
    {
        _rigidbody.MovePosition(_rigidbody.position + movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(rotation);
    }

}
