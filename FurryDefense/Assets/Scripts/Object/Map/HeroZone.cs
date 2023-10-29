using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public static Action<HeroZone> OnClickHeroZone { get; set; }

    [SerializeField]
    private GameObject _possibleZone;

    [SerializeField]
    private GameObject _impossibleZone;

    public bool IsStandingHero;

    private HeroSpawner _heroSpawner;
    private HeroZoneHandler _heroZoneHandler;

    private void Awake()
    {
        _heroSpawner = FindObjectOfType<HeroSpawner>();
        _heroZoneHandler = FindObjectOfType<HeroZoneHandler>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(_heroSpawner.IsSpawnedHero)
        {
            Debug.Log("HeroZone Enter");
            _heroSpawner.SetHeroZone(this);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_heroSpawner.IsSpawnedHero)
        {
            Debug.Log("HeroZone Exit");
            _heroSpawner.SetHeroZone(null);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_heroZoneHandler.IsReadyChanging)
        {
            _heroZoneHandler.ChangeZone(this);
        }
    }

    public void CheckChange()
    {
        if (IsStandingHero)
        {
            _impossibleZone.SetActive(true);
        }
        else
        {
            _possibleZone.SetActive(true);
        }
    }

    public void EndChange()
    {
        _impossibleZone.SetActive(false);
        _possibleZone.SetActive(false);
    }
}
