using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private SpawnPoint _spawnPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isGround;
    private float _horizontalMove;
    private string _isSpeed = "Speed";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if(collision.collider.TryGetComponent(out Enemy enemy))
        {
            Respawn();
        }        
        else
        {
            UpdateGround(collision, true);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        UpdateGround(collision, false);
    }

    private void UpdateGround(Collision2D collision2D, bool value)
    {
        if (collision2D.collider.TryGetComponent(out Ground ground))
        {
            _isGround = value;
        }
    }

    private void Move()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");
        _rigidbody2D.velocity = new Vector2(_horizontalMove * _speed, _rigidbody2D.velocity.y);
        _animator.SetFloat(SetHashes(_isSpeed), Mathf.Abs(_horizontalMove));
        Flip();
    }

    private void Jump()
    {
        if(Input.GetAxis("Jump") > 0)
        {
            if (_isGround)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 1 * _jumpPower); 
            }           
        }
    }

    private void Flip()
    {
        if (_horizontalMove == 1)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_horizontalMove == -1)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void Respawn()
    {
        transform.position = _spawnPoint.transform.position;
    }

    private int SetHashes(string name)
    {
        return Animator.StringToHash(name);
    }
}
