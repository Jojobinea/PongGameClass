using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public AudioSource _ballAudioSource;
    public float speedForce;
    public float secondsDelay;
    public Vector2[] startDirection;
    public AudioClip _collisionColClip;
    public AudioClip _scoreClip;

    private GameController _gameController;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.FindAnyObjectByType<GameController>();

        ResetPosition();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Score"))
        {
            if(transform.position.x > 0)
            {
                _gameController.AddScore(true);
            }
            else if(transform.position.x < 0)
            {
                _gameController.AddScore(false);
            }

            _ballAudioSource.PlayOneShot(_scoreClip);
            ResetPosition();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _ballAudioSource.PlayOneShot(_collisionColClip);
    }

    private void ResetPosition()
    {
        transform.position = new Vector3(0, 0, -3);
        rb.velocity = Vector3.zero;

        StartCoroutine(MovementDelay(secondsDelay));
    }

    private IEnumerator MovementDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        int i = Random.Range(0, startDirection.Length);
        rb.velocity = startDirection[i] * speedForce;
    }
}
