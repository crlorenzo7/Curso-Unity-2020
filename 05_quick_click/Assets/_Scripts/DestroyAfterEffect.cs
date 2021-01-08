using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterEffect : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem _particleSystem;

    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, _particleSystem.main.duration + _particleSystem.main.startLifetimeMultiplier);
    }
}
