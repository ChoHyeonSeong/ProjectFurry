using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Hero StandingHero { get; set; }

    private HeroSpawner _heroSpawner;
    private HeroZoneHandler _heroZoneHandler;


    private void Awake()
    {
        _heroSpawner = FindObjectOfType<HeroSpawner>();
        _heroZoneHandler = FindObjectOfType<HeroZoneHandler>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("HeroZone Enter");
        _heroSpawner.ChangeHeroZone(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("HeroZone Exit");
        _heroSpawner.ChangeHeroZone(null);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(_heroZoneHandler.IsReadyChanging)
        {
            _heroZoneHandler.ChangeZone(this);
        }
    }
}
