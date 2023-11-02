using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameView : MonoBehaviour
{
    [SerializeField]
    private GameObject _landingBtnParent;

    [SerializeField]
    private HeartPointBar _heartPointBarPrefab;

    [SerializeField]
    private Transform _heartPointBarParent;

    [SerializeField]
    private TextMeshProUGUI _monsterCountText;

    [SerializeField]
    private TextMeshProUGUI _currentCostText;

    [SerializeField]
    private TextMeshProUGUI _waveCountText;

    [SerializeField]
    private TextMeshProUGUI _gameSpeedText;


    private List<LandingButton> _landingBtnList;


    public void ActiveLandingButton(int index)
    {
        _landingBtnList[index].gameObject.SetActive(true);
    }

    private void Awake()
    {
        _landingBtnList = _landingBtnParent.GetComponentsInChildren<LandingButton>().ToList();
    }

    private void OnEnable()
    {
        InGameHandler.OnSetCurrentCost += ChangeCurrentCostText;
        InGameHandler.OnSetWaveCount += ChangeWaveCountText;
        InGameHandler.OnSetMonsterCount += ChangeMonsterCountText;
        InGameHandler.OnSetGameSpeed += ChangeGameSpeedText;
        InGameHandler.OnSetHeroFormation += InitLandingButton;
        MonsterSpawner.OnSpawnMonster += GenerateMonsterHPBar;
    }

    private void OnDisable()
    {
        InGameHandler.OnSetCurrentCost -= ChangeCurrentCostText;
        InGameHandler.OnSetWaveCount -= ChangeWaveCountText;
        InGameHandler.OnSetMonsterCount -= ChangeMonsterCountText;
        InGameHandler.OnSetGameSpeed -= ChangeGameSpeedText;
        InGameHandler.OnSetHeroFormation -= InitLandingButton;
        MonsterSpawner.OnSpawnMonster -= GenerateMonsterHPBar;
    }

    private void GenerateMonsterHPBar(Monster monster)
    {
        HeartPointBar hpBar = Instantiate(_heartPointBarPrefab, _heartPointBarParent);
        hpBar.SetMonster(monster);
    }

    private void ChangeMonsterCountText(int value)
    {
        _monsterCountText.text = value.ToString();
    }

    private void ChangeCurrentCostText(int value)
    {
        _currentCostText.text = value.ToString();
    }

    private void ChangeWaveCountText(int current, int max)
    {
        _waveCountText.text = $"{current}/{max}";
    }

    private void ChangeGameSpeedText(int value)
    {
        _gameSpeedText.text = value.ToString();
    }

    private void InitLandingButton(List<int> heroIdList)
    {
        for (int i = 0; i < _landingBtnList.Count; i++)
        {
            _landingBtnList[i].Init(i < heroIdList.Count ? heroIdList[i] : -1);
        }
    }
}
