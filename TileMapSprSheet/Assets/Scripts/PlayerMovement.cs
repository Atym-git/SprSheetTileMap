using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    [SerializeField] private Animator _animator;

    [SerializeField] private KeyCode _jumpKey;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float overlapRadius;

    private bool _isGrounded = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Jump();
        CheckGround();
    }
    private void Move()
    {
        float movementX = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(movementX * _speed, _rb.velocity.y);

        if (movementX > 0)
        {
            _sr.flipX = false;
            _animator.SetBool("Running", true);
        }
        else if (movementX < 0)
        {
            _sr.flipX = true;
            _animator.SetBool("Running", true);
        }
        else
        {
            _animator.SetBool("Running", false);
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(_jumpKey) && _isGrounded)
        {
            Debug.Log(_isGrounded);
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, overlapRadius, groundLayerMask);
    }
}
