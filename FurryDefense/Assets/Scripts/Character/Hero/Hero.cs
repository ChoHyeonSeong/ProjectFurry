using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public enum EHeroState
{
    READY,
    IDLE,
    ATTACK,
}

public class Hero : MonoBehaviour, IPointerClickHandler
{
    public static Action<Hero> OnClickHero { get; set; }

    public int HeroIndex { get; private set; }
    public HeroZone MyZone { get; set; }


    private List<Vector2Int> _realAttackRange;
    private List<MonsterZone> _targetMonsterZoneList;

    private MonsterZoneHandler _monsterZoneHandler;

    private BoxCollider2D _boxCollider;

    private bool _isLanded;
    private bool _possibleAttack;

    private int _attackDamage;
    private int _attackNum;
    private float _attackTime;
    private List<Vector2Int> _attackRange;

    public void LandHero(int index)
    {
        HeroIndex = index;
        _boxCollider.enabled = true;
        _isLanded = true;
        _possibleAttack = true;
        HideTargetMonsterZone();
    }

    private void Awake()
    {
        _attackRange = new List<Vector2Int>
        {
            new Vector2Int(1, 0)
        };
        _monsterZoneHandler = FindObjectOfType<MonsterZoneHandler>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _isLanded = false;
        _possibleAttack = false;
        _attackTime = 0.2f;
        _attackDamage = 1;
        _attackNum = 1;
    }

    private void Update()
    {
        if(_isLanded)
        {
            if(_possibleAttack)
            {
                List<Monster> monsterList = new List<Monster>();
                foreach(MonsterZone zone in _targetMonsterZoneList)
                {
                    monsterList.AddRange(zone.MonsterList);
                }
                if(monsterList.Count > 0)
                {
                    for (int i = 0; i < monsterList.Count && i<_attackNum; i++)
                    {
                        monsterList[i].PlusHeartPoint(-_attackDamage);
                    }
                    StartCoroutine(CoExecuteAttack());
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickHero(this);
    }

    public void CalculrateAttackRange(HeroZone heroZone)
    {
        Vector2Int coefficient = Vector2Int.one;
        bool isReserve = false;
        switch (heroZone.AttackDirection)
        {
            case EDirection.NORTH:
                isReserve = true;
                coefficient = new Vector2Int(1, -1);
                break;
            case EDirection.SOUTH:
                isReserve = true;
                coefficient = new Vector2Int(-1, 1);
                break;
            case EDirection.EAST:
                isReserve = false;
                coefficient = new Vector2Int(-1, 1);
                break;
            case EDirection.WEST:
                isReserve = false;
                coefficient = new Vector2Int(1, 1);
                break;
        }

        Vector2Int range= Vector2Int.zero;
        _realAttackRange = new List<Vector2Int>();
        for (int i = 0; i < _attackRange.Count; i++)
        {
            if(isReserve)
            {
                range.Set(_attackRange[i].y, _attackRange[i].x);
            }
            else
            {
                range.Set(_attackRange[i].x, _attackRange[i].y);
            }
            range *= coefficient;
            _realAttackRange.Add(heroZone.GetZoneArrayPosition() + range);
        }

        _targetMonsterZoneList = _monsterZoneHandler.GetTargetMonsterZone(_realAttackRange);
    }

    public void ShowTargetMonsterZone()
    {
        foreach (MonsterZone zone in _targetMonsterZoneList)
        {
            zone.ShowAttackRange();
        }
    }
    public void HideTargetMonsterZone()
    {
        foreach (MonsterZone zone in _targetMonsterZoneList)
        {
            zone.HideAttackRange();
        }
    }

    private IEnumerator CoExecuteAttack()
    {
        Debug.Log("Attack Monster");
        _possibleAttack = false;
        yield return new WaitForSeconds(_attackTime);
        _possibleAttack = true;
    }
}
