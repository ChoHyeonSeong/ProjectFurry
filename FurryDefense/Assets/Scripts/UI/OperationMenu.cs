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

    private void Awake()
    {
        _inGameView = FindObjectOfType<InGameView>();
        gameObject.SetActive(false);
        _retreatBtn.onClick.AddListener(RetreatHero);
    }

    private void OnEnable()
    {
        Hero.OnClickHero += ShowMenu;
    }

    private void OnDisable()
    {
        Hero.OnClickHero += ShowMenu;
    }

    private void ShowMenu(Hero hero)
    {
        _selectedHero = hero;
        transform.position = Camera.main.WorldToScreenPoint(hero.transform.position);
        gameObject.SetActive(true);
    }

    private void RetreatHero()
    {
        _inGameView.ActiveLandingButton(_selectedHero.HeroIndex);
        Destroy(_selectedHero.gameObject);
        _selectedHero = null;
        gameObject.SetActive(false);
    }
}
