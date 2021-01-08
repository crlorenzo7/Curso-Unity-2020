using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    Rigidbody _rigidbody;
    public float forceMaxValue = 14f;
    public float forceMinValue = 10f;
    public float maxTorque = 10f;
    public float minTorque = -10f;
    public float rotationSpeed = 30f;

    public GameObject destructionEffect;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        LaunchTarget();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 rotation = rotationSpeed * new Vector3(1f, 1f, 0f);
        //transform.Rotate(rotation * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        Instantiate(destructionEffect, transform.position, destructionEffect.transform.rotation);
        Destroy(gameObject);
    }

    ///<summary>Aplica al gameObject una fuerza y torque de lanzamiento</summary>
    void LaunchTarget()
    {
        float forceValue = Random.Range(forceMinValue, forceMaxValue);
        float torqueValue = Random.Range(minTorque, maxTorque);

        _rigidbody.AddForce(forceValue * transform.up, ForceMode.Impulse);
        _rigidbody.AddTorque(torqueValue * Vector3.one, ForceMode.Impulse);
    }


}
