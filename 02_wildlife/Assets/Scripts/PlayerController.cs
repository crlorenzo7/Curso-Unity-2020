using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public List<GameObject> projectiles = new List<GameObject>();

    //OPCIONES DE TIRO
    public float timeBetweenFires = 0.5f;
    private float nextFireTime = 0.0f;
    private float currentTime = 0.0f;

    //MARCO DEL JUEGO
    public Vector2 xRange = new Vector2(-15f, 15f);
    public Vector2 zRange = new Vector2(0f, 15f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        MovePlayer();

        if (Input.GetButton("Fire1"))
        {
            Fire();
        }

    }

    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 horizontalTranslation = speed * horizontalInput * Time.deltaTime * Vector3.right;
        Vector3 verticalTranslation = speed * verticalInput * Time.deltaTime * Vector3.forward;

        transform.Translate(horizontalTranslation + verticalTranslation);
        AdjustPosition();
    }

    private void AdjustPosition()
    {
        float xValue = GetValueInRange(transform.position.x, xRange);
        float zValue = GetValueInRange(transform.position.z, zRange);

        transform.position = new Vector3(xValue, transform.position.y, zValue);
    }

    private float GetValueInRange(float value, Vector2 range)
    {
        value = value > range.y ? range.y : value;
        value = value < range.x ? range.x : value;
        return value;
    }

    private void Fire()
    {
        if (currentTime > nextFireTime)
        {
            nextFireTime = currentTime + timeBetweenFires;

            int projectileIndex = Random.Range(0, projectiles.Count);
            GameObject projectile = projectiles[projectileIndex];
            Vector3 initialPosition = transform.position + new Vector3(0f, 1f, 0f);
            Instantiate(projectile, initialPosition, transform.rotation);

            nextFireTime -= currentTime;
            currentTime = 0f;
        }
    }

}
