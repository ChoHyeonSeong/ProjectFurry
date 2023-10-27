using System;
using System.Collections;
using System.Collections.Generic;
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


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Hero OnMouseDown");
        OnClickHero(this);
    }
}
