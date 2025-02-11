using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    [SerializeField] private Animator _animator;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        float movementX = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(movementX * _speed, _rb.velocity.y);

        if (movementX > 0)
        {
        _sr.flipX = false;
        }
        else if (movementX < 0)
        {
            _sr.flipX = true;
        }
        else
        {
        
        }
    }
}
