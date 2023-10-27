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
            ReadyHeroLanding(_heroIndex, exitPos);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position -= _selectedPos;
        _isPointerDowned = false;
    }

    private void ReadyHeroLanding(int index, Vector3 exitPos)
    {
        _heroSpawner.SpawnHero(index, exitPos, gameObject);
    }

}
