using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject[] _transforms;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isAnimation;

    private Transform _positionTwo;
    private SpriteRenderer _spriteRenderer;
    private int _point = 0;
    private float _startSpeed;

    private void Start()
    {
        _startSpeed = _speed;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _positionTwo = _transforms[_point].transform;
    }

    private void Update()
    {
        _speed = _startSpeed;

        if (transform.position == _positionTwo.position)
        {
            _point++;

            if (_point >= _transforms.Length)
            {
                _point = 0;
            }

            _positionTwo = _transforms[_point].transform;
        }

        if (_isAnimation)
        {
            if (_positionTwo.position.x - transform.position.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }      

        transform.position = Vector3.MoveTowards(transform.position, _positionTwo.position, _speed * Time.deltaTime);
    }
}
