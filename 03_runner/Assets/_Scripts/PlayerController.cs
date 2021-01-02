using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    const string DIRT_ANIMATION_DELAY = "DirtAnimationDelay";
    const string RESTART_GAME = "RestartGame";

    private Rigidbody rb;
    public float jumpForce = 10f;
    public float forwardForce = 20f;
    public bool grounded = true;
    private bool _gameOver;
    private Animator _animator;
    public ParticleSystem explosion, dirtTrace;
    public AudioClip jumpSound, crashSound;
    private bool startDirt;
    private AudioSource _soundPlayer, _backgroundSound;

    public bool GameOver
    {
        get => _gameOver;
        set => _gameOver = value;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat(AnimConstants.SPEED_F, forwardForce);
        _backgroundSound = GameObject.FindWithTag(Tags.MAIN_CAMERA).GetComponent<AudioSource>();
        _soundPlayer = GetComponent<AudioSource>();
        StartCoroutine(DIRT_ANIMATION_DELAY);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!GameOver)
        {
            if (Input.GetKey(KeyCode.UpArrow) && grounded)
            {
                _animator.SetTrigger(AnimConstants.JUMP_TRIG);
                rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
                _soundPlayer.PlayOneShot(jumpSound);
                grounded = false;
                _animator.SetBool(AnimConstants.GROUNDED, false);
                dirtTrace.Stop();
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(Tags.GROUND) && !GameOver)
        {
            _animator.ResetTrigger(AnimConstants.JUMP_TRIG);
            _animator.SetBool(AnimConstants.GROUNDED, true);
            grounded = true;
            if (startDirt)
            {
                dirtTrace.Play();
            }

        }
        if (other.gameObject.CompareTag(Tags.OBSTACLE))
        {
            _animator.SetFloat(AnimConstants.SPEED_F, 0);
            _animator.SetBool(AnimConstants.GROUNDED, true);
            _animator.SetBool(AnimConstants.DEATH_B, true);
            _soundPlayer.PlayOneShot(crashSound);
            dirtTrace.Stop();
            explosion.Play();
            _backgroundSound.Stop();
            GameOver = true;
            Invoke(RESTART_GAME, 2f);
        }
    }

    IEnumerator DirtAnimationDelay()
    {
        yield return new WaitForSeconds(3f);
        dirtTrace.Play();
        startDirt = true;
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Prototype 3");
    }



}
