using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    public int killGoodPenalty = -1;

    GameManager _gameManager;
    Launch _launchScript;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _launchScript = GetComponent<Launch>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("killZone"))
        {
            if (_launchScript.TypeOfTarget == TargetType.GOOD)
            {
                _gameManager.UpdateScore(killGoodPenalty);
            }
            Destroy(gameObject);
        }
    }
}
