﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("killZone"))
        {
            Destroy(gameObject);
        }
    }
}
