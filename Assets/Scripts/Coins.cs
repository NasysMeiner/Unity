using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private Money _prefab;

    private Transform[] _points;

    private void Start()
    {       
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = transform.GetChild(i).transform;
            Instantiate(_prefab, _points[i].position, Quaternion.identity);
        }
    }
}
