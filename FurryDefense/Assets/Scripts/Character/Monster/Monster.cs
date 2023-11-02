using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public Action OnPlusHeartPoint { get; set; }
    public static Action<Monster> OnDieMonster { get; set; }
    public int MaxHP { get; private set; }
    public int CurrentHP { get; private set; }
    public int StrikingPower { get; private set; }
    public int DropCost { get; private set; }

    private bool _isDie;
    private Vector3 _moveDirection;
    private float _moveSpeed;

    public void InitMonster(MonsterData data, Vector3 direction)
    {
        MaxHP = data.HeartPoint;
        StrikingPower = data.StrikingPower;
        DropCost = data.DropCost;
        _moveSpeed = data.MoveSpeed;
        ChangeMoveDirection(direction);
        CurrentHP = MaxHP;
        _isDie = false;
    }

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
            OnDieMonster(this);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(!_isDie)
        {
            transform.position += _moveDirection * Time.deltaTime * _moveSpeed;
        }
    }
}
