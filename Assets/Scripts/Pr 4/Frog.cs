using UnityEngine;

public class Frog : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _sprite;

    private float _speed = 8f;
    private float _jumpForce = 6f;

    private bool _isGround;
    private int _jumpCount = 0;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontal * _speed, _rb.velocity.y);

        if (horizontal != 0 && _isGround)
        {
            _sprite.flipX = horizontal < 0;
            _anim.Play("Run");
        }

        if (horizontal == 0 && _isGround)
            _anim.Play("Idle");

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        if (_isGround || _jumpCount <= 1)
        {
            _anim.Play("Jump");
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);

            _jumpCount++;
            if (_jumpCount > 1)
                _anim.Play("DoubleJump");

            if (_isGround)
                _isGround = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
            _jumpCount = 0;
        }
    }

}
