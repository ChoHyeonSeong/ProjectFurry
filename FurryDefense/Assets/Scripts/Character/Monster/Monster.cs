using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    private bool _isDie;
    private Vector3 _moveDirection;
    private float _moveSpeed;

    public void ChangeMoveDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }

    private void Awake()
    {
        _isDie = false;
        _moveDirection = Vector3.zero;
        _moveSpeed = 1;
    }

    private void Update()
    {
        if(!_isDie)
        {
            transform.position += _moveDirection * Time.deltaTime * _moveSpeed;
        }
    }
}
