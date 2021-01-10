using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum TargetType { GOOD, BAD, DEATH };

public class Launch : MonoBehaviour
{

    Rigidbody _rigidbody;
    private GameManager _gameManager;

    public float forceMaxValue = 14f;
    public float forceMinValue = 10f;
    public float maxTorque = 10f;
    public float minTorque = -10f;

    public int scoreValue = 1;

    [SerializeField]
    private TargetType typeOfTarget;
    public ParticleSystem destructionEffect;

    public TargetType TypeOfTarget { get => typeOfTarget; set => typeOfTarget = value; }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

        LaunchTarget();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (_gameManager.GameState != GameState.GAMEOVER)
        {
            switch (TypeOfTarget)
            {
                case TargetType.GOOD:
                case TargetType.BAD: _gameManager.UpdateScore(scoreValue); break;
                case TargetType.DEATH: _gameManager.FinishGame(); break;
            }

            Instantiate(destructionEffect, transform.position, destructionEffect.transform.rotation);
            Destroy(gameObject);
        }
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
