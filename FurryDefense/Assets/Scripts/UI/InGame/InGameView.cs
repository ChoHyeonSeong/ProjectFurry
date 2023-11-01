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
    private List<GameObject> _landingBtnList;

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


    public void ActiveLandingButton(int index)
    {
        _landingBtnList[index].SetActive(true);
    }

    private void OnEnable()
    {
        InGameHandler.OnSetCurrentCost += ChangeCurrentCostText;
        InGameHandler.OnSetWaveCount += ChangeWaveCountText;
        InGameHandler.OnSetMonsterCount += ChangeMonsterCountText;
        InGameHandler.OnSetGameSpeed += ChangeGameSpeedText;
        MonsterSpawner.OnSpawnMonster += GenerateMonsterHPBar;
    }

    private void OnDisable()
    {
        InGameHandler.OnSetCurrentCost -= ChangeCurrentCostText;
        InGameHandler.OnSetWaveCount -= ChangeWaveCountText;
        InGameHandler.OnSetMonsterCount -= ChangeMonsterCountText;
        InGameHandler.OnSetGameSpeed -= ChangeGameSpeedText;
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

    private void ChangeWaveCountText(int value)
    {
        _waveCountText.text = value.ToString();
    }

    private void ChangeGameSpeedText(int value)
    {
        _gameSpeedText.text = value.ToString();
    }
}
