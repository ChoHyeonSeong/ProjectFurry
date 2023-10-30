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


    private List<Vector2Int> _originAttackRange;
    private List<Vector2Int> _realAttackRange;
    private List<MonsterZone> _targetMonsterZoneList;

    private MonsterZoneHandler _monsterZoneHandler;

    private BoxCollider2D _boxCollider;

    private bool _isLanded;
    private bool _possibleAttack;

    private float _attackTime;

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
        _originAttackRange = new List<Vector2Int>
        {
            new Vector2Int(1, 0)
        };
        _monsterZoneHandler = FindObjectOfType<MonsterZoneHandler>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _isLanded = false;
    }

    private void Update()
    {
        if(_isLanded)
        {
            if(_possibleAttack)
            {

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
        for (int i = 0; i < _originAttackRange.Count; i++)
        {
            if(isReserve)
            {
                range.Set(_originAttackRange[i].y, _originAttackRange[i].x);
            }
            else
            {
                range.Set(_originAttackRange[i].x, _originAttackRange[i].y);
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

    private IEnumerator CoCheckAttack()
    {
        _possibleAttack = false;
        yield return new WaitForSeconds(_attackTime);
        _possibleAttack = true;
    }
}
