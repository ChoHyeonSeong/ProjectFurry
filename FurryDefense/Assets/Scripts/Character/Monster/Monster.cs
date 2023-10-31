using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public Action OnPlusHeartPoint { get; set; }
    public Action OnDieMonster { get; set; }
    public int MaxHP { get; private set; }
    public int CurrentHP { get; private set; }
    private bool _isDie;
    private Vector3 _moveDirection;
    private float _moveSpeed;

    public void ChangeMoveDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }

    public void PlusHeartPoint(int point)
    {
        CurrentHP += point;
        OnPlusHeartPoint();
        if( CurrentHP <= 0 )
        {
            _isDie = true;
            OnDieMonster();
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        _isDie = false;
        _moveDirection = Vector3.zero;
        _moveSpeed = 1;
        MaxHP = 10;
        CurrentHP = MaxHP;
    }

    private void Update()
    {
        if(!_isDie)
        {
            transform.position += _moveDirection * Time.deltaTime * _moveSpeed;
        }
    }
}
