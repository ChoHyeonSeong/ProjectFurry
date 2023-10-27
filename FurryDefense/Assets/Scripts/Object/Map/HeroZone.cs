using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroZone : MonoBehaviour
{
    private HeroSpawner _heroSpawner;


    private void Awake()
    {
        _heroSpawner = FindObjectOfType<HeroSpawner>();
    }


    private void OnMouseEnter()
    {
        _heroSpawner.ChangeHeroZone(gameObject);
    }

    private void OnMouseExit()
    {
        _heroSpawner.ChangeHeroZone(null);
    }
}
