using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class LandingButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField]
    private int _heroID;

    private Vector3 _selectedPos = new Vector3(0, 50, 0);
    private bool _isPointerDowned;
    private HeroSpawner _heroSpawner;

    private void Awake()
    {
        _heroSpawner = FindObjectOfType<HeroSpawner>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.position += _selectedPos;
        _isPointerDowned = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(_isPointerDowned)
        {
            Vector3 exitPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            exitPos.z = 0;
            ReadyHeroLanding(_heroID, exitPos);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position -= _selectedPos;
        _isPointerDowned = false;
    }

    private void ReadyHeroLanding(int id, Vector3 exitPos)
    {
        _heroSpawner.SpawnHero(id, exitPos);
    }
}
