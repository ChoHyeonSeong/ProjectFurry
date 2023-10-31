using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    private int _heartPoint;
    private bool _isDie;
    private Vector3 _moveDirection;
    private float _moveSpeed;

    public void ChangeMoveDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }

    public void PlusHeartPoint(int point)
    {
        _heartPoint += point;
        if( _heartPoint < 0 )
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        _isDie = false;
        _moveDirection = Vector3.zero;
        _moveSpeed = 1;
        _heartPoint = 10;
    }

    private void Update()
    {
        if(!_isDie)
        {
            transform.position += _moveDirection * Time.deltaTime * _moveSpeed;
        }
    }
}
