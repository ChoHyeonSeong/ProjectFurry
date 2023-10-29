using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroZoneHandler : MonoBehaviour
{
    public static Action OnFailChangeZone { get; set; }

    public bool IsReadyChanging { get; private set; }

    private Hero _tempHero;
    private List<HeroZone> _heroZoneList;

    private void Awake()
    {
        IsReadyChanging = false;
        _heroZoneList = GetComponentsInChildren<HeroZone>().ToList();
        Outside.OnClickOutside += CancelChanging;
    }

    private void OnDestroy()
    {
        Outside.OnClickOutside -= CancelChanging;
    }

    public void ReadyChanging(Hero hero)
    {
        _tempHero = hero;
        IsReadyChanging = true;
        foreach (HeroZone zone in _heroZoneList)
        {
            zone.CheckChange();
        }
    }

    public void ChangeZone(HeroZone zone)
    {
        if(!zone.IsStandingHero)
        {
            _tempHero.transform.position = zone.transform.position;
            zone.IsStandingHero = true;
            _tempHero.MyZone.IsStandingHero = false;
            _tempHero.MyZone = zone;
        }
        else
        {
            OnFailChangeZone();
        }
        CancelChanging();
    }

    private void CancelChanging()
    {
        _tempHero = null;
        IsReadyChanging = false;
        foreach (HeroZone zone in _heroZoneList)
        {
            zone.EndChange();
        }
    }
}
