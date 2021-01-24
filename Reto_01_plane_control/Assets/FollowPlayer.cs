using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject pov;
    public Vector3 offset = new Vector3(0, 5, 10);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 offset = Quaternion.AngleAxis (Input.GetAxis() * turnSpeed, Vector3.up) * offset;
        //  transform.position = player.position + offset; 
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);

        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);

    }
}
