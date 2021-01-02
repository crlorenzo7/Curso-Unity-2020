using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyX : MonoBehaviour
{
    const string PLAYER_GOAL = "Player Goal";
    const string ENEMY_GOAL = "Enemy Goal";
    public float speed;
    private Rigidbody enemyRb;
    public GameObject playerGoal;
    private ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find(PLAYER_GOAL);
        particles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == ENEMY_GOAL)
        {
            DestroyBall();
        }
        if (other.gameObject.name == PLAYER_GOAL)
        {
            DestroyBall();
            new WaitForSeconds(2f);
            SceneManager.LoadScene("Challenge 4");
        }


    }

    void DestroyBall()
    {
        particles.Play();
        Destroy(gameObject);
    }

}
