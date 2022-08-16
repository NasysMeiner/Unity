using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isAnimation;

    private Transform _positionTwo;
    private SpriteRenderer _spriteRenderer;
    private Transform[] _points;
    private int _point = 0;
    private float _startSpeed;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startSpeed = _speed;
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _positionTwo = _points[_point].transform;
    }

    private void Update()
    {
        _speed = _startSpeed;

        if (transform.position == _positionTwo.position)
        {
            _point++;

            if (_point >= _points.Length)
            {
                _point = 0;
            }

            _positionTwo = _points[_point].transform;
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
