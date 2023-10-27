using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EHeroState
{
    READY,
    IDLE,
    ATTACK,
}

public class Hero : MonoBehaviour
{
    public int HeroIndex { get; private set; }
    public static Action<Hero> OnClickHero { get; set; }
    private BoxCollider2D _boxCollider;

    public void LandHero(int index)
    {
        HeroIndex = index;
        _boxCollider.enabled = true;
    }

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
        OnClickHero(this);
    }
}
