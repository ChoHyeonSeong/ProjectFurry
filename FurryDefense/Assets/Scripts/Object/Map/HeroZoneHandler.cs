using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroZoneHandler : MonoBehaviour
{
    public bool IsReadyChanging { get; private set; }

    private Hero _tempHero;

    private void Awake()
    {
        IsReadyChanging = false;
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
    }

    public void ChangeZone(HeroZone zone)
    {
        _tempHero.transform.position = zone.transform.position;
        zone.StandingHero = _tempHero;
        CancelChanging();
    }

    private void CancelChanging()
    {
        _tempHero = null;
        IsReadyChanging = false;
    }
}
