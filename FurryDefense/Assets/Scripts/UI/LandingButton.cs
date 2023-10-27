using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class LandingButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField]
    private int _heroIndex;

    private Vector3 _selectedPos = new Vector3(0, 50, 0);
    private bool _isPointerDowned;
    private HeroSpawner _heroSpawner;

    private void Awake()
    {
        _heroSpawner = FindObjectOfType<HeroSpawner>();
    }

    public void SuccessHeroLanding()
    {
        gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.position += _selectedPos;
        _isPointerDowned = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_isPointerDowned && !_heroSpawner.IsSpawnedHero)
        {
            Vector3 exitPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            exitPos.z = 0;
            _heroSpawner.SpawnHero(_heroIndex, exitPos, gameObject);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position -= _selectedPos;
        _isPointerDowned = false;
        _heroSpawner.TryLandingHero();
    }
}
