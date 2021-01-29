using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0f, 17f, -15f);
    public float prevRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        float yRotation = player.transform.eulerAngles.y - prevRotation;
        transform.RotateAround(player.transform.position, Vector3.up, yRotation);
        transform.LookAt(player.transform.position);
        prevRotation = player.transform.eulerAngles.y;
        // transform.LookAt(player.transform.position);
        // transform.rota

        // prevPlayerPosition = transform.position;

    }
}
