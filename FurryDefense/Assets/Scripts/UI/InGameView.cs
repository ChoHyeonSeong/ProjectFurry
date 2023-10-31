using System.Collections;
using System.Collections.Generic;
using System.Linq;
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


    public void ActiveLandingButton(int index)
    {
        _landingBtnList[index].SetActive(true);
    }

    private void OnEnable()
    {
        MonsterSpawner.OnSpawnMonster += GenerateMonsterHPBar;
    }

    private void OnDisable()
    {
        MonsterSpawner.OnSpawnMonster -= GenerateMonsterHPBar;
    }

    private void GenerateMonsterHPBar(Monster monster)
    {
        HeartPointBar hpBar = Instantiate(_heartPointBarPrefab, _heartPointBarParent);
        hpBar.SetMonster(monster);
    }
}
