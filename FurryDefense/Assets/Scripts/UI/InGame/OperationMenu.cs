using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperationMenu : MonoBehaviour
{
    [SerializeField]
    private Button _retreatBtn;
    [SerializeField]
    private Button _changeZoneBtn;

    private Hero _selectedHero;
    private InGameView _inGameView;
    private HeroZoneHandler _heroZoneHandler;

    private void Awake()
    {
        _inGameView = FindObjectOfType<InGameView>();
        _heroZoneHandler = FindObjectOfType<HeroZoneHandler>();
        _retreatBtn.onClick.AddListener(RetreatHero);
        _changeZoneBtn.onClick.AddListener(ChangeZone);

        Hero.OnClickHero += ShowMenu;
        Outside.OnClickOutside += HideMenu;

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Hero.OnClickHero -= ShowMenu;
        Outside.OnClickOutside -= HideMenu;
    }

    private void ShowMenu(Hero hero)
    {
        _selectedHero = hero;
        transform.position = Camera.main.WorldToScreenPoint(_selectedHero.transform.position);
        gameObject.SetActive(true);
    }

    private void HideMenu()
    {
        _selectedHero = null;
        gameObject.SetActive(false);
    }

    private void RetreatHero()
    {
        _inGameView.ActiveLandingButton(_selectedHero.HeroIndex);
        _selectedHero.MyZone.IsStandingHero = false;
        _selectedHero.MyZone = null;
        Destroy(_selectedHero.gameObject);
        _selectedHero = null;
        gameObject.SetActive(false);
    }

    private void ChangeZone()
    {
        _heroZoneHandler.ReadyChanging(_selectedHero);
        _selectedHero = null;
        gameObject.SetActive(false);
    }
}
