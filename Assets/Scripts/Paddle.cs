using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Variables
    public float speed;
    public bool isPlayerOne;
    public ParticleSystem _particleSystem;
    private bool _isPressingUp;
    private bool _isPressingDown;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerOne)
        {
            _isPressingUp = Input.GetKey(KeyCode.W);
            _isPressingDown = Input.GetKey(KeyCode.S);
        }
        else
        {
            _isPressingUp = Input.GetKey(KeyCode.UpArrow);
            _isPressingDown = Input.GetKey(KeyCode.DownArrow);
        }

        if(_isPressingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            _spriteRenderer.flipY = false;
        }
        else if (_isPressingDown)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            _spriteRenderer.flipY = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ball"))
            _particleSystem.Play();
    }
}
