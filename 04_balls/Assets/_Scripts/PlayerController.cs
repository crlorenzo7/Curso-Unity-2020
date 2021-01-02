using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedForce;
    public float boostForce = 5f;

    Rigidbody _rb;
    public GameObject focalPoint;

    bool hasPowerUp = false;

    float powerUpDuration = 5f;
    float repulsionPowerUpForce = 50f;
    public GameObject[] powerUpIndicators;
    Vector3 powerUpIndicatorPosition;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        powerUpIndicatorPosition = powerUpIndicators[0].transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vValue = Input.GetAxis("Vertical");

        ForceMode modeApplication = ForceMode.Force;

        float vForce = vValue * speedForce;
        Vector3 finalForce = vForce * focalPoint.transform.forward;

        _rb.AddForce(finalForce, modeApplication);


    }

    void Update()
    {
        if (transform.position.y < -15f)
        {
            SceneManager.LoadScene("Prototype 4");
        }
        foreach (GameObject puIndicator in powerUpIndicators)
        {
            puIndicator.transform.position = new Vector3(transform.position.x, transform.position.y - 0.75f, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        GameObject trigger = other.gameObject;
        if (trigger.CompareTag("PowerUp") && !hasPowerUp)
        {
            StartCoroutine(GetPowerUp());
            Destroy(trigger);
        }
    }

    ///<summary>
    /// Corutina que activa un powerup por un tiempo y lo desactiva cuando el tiempo termina
    ///</summary>
    private IEnumerator GetPowerUp()
    {
        hasPowerUp = true;
        for (int i = 0; i < powerUpIndicators.Length; i++)
        {
            powerUpIndicators[i].SetActive(true);
            yield return new WaitForSeconds(powerUpDuration / 3);
            powerUpIndicators[i].SetActive(false);

        }

        Debug.Log("time powerup over");
        hasPowerUp = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyN1") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();

            Vector3 forceDirection = other.gameObject.transform.position - transform.position;
            Vector3 reverseForce = repulsionPowerUpForce * forceDirection;

            enemyRigidbody.AddForce(reverseForce, ForceMode.Impulse);
        }
    }

}
