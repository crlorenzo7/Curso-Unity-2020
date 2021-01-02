using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private bool gameOver;

    public float upBound = 10f;

    public float floatForce = 5f;
    private float gravityModifier = 1.5f;
    private float initForce = 5f;
    private Rigidbody playerRb;
    private Vector3 gravity = new Vector3(0, -9.81f, 0);

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    public bool GameOver { get => gameOver; set => gameOver = value; }


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = gravity * gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * initForce, ForceMode.Impulse);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // While space is pressed and player is low enough, float up

        if (Input.GetKey(KeyCode.Space) && !GameOver && transform.position.y < upBound)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Force);

        }
    }

    void Update()
    {
        if (transform.position.y >= upBound)
        {
            Vector3 currentVelocity = playerRb.velocity;
            currentVelocity.y = 0;
            playerRb.velocity = currentVelocity;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            //playerRb.constraints = RigidbodyConstraints.FreezeAll;
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            GameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        fireworksParticle.transform.position = other.transform.position;
        fireworksParticle.Play();
        playerAudio.PlayOneShot(moneySound, 1.0f);
        Destroy(other.gameObject);
    }

}
