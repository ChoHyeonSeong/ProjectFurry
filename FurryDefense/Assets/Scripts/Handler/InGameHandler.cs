using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameHandler : MonoBehaviour
{
    public static Action<int> OnSetCurrentCost { get; set; }
    public static Action<int> OnSetGameSpeed { get; set; }
    public static Action<int> OnSetWaveCount { get; set; }
    public static Action<int> OnSetMonsterCount { get; set; }

    public int CurrentCost 
    {
        get => _currentCost;
        private set 
        { 
            _currentCost = value; 
            OnSetCurrentCost(_currentCost);
        } 
    }

    public int GameSpeed
    {
        get => _gameSpeed;
        private set
        {
            _gameSpeed = value;
            OnSetGameSpeed(_gameSpeed);
        }
    }

    public int WaveCount
    {
        get => _waveCount;
        private set
        {
            _waveCount = value;
            OnSetWaveCount(_waveCount);
        }
    }

    public int MonsterCount
    {
        get => _monsterCount;
        private set
        {
            _monsterCount = value;
            OnSetMonsterCount(_monsterCount);
        }
    }

    private int _currentCost;
    private int _gameSpeed;
    private int _waveCount;
    private int _monsterCount;

    private MonsterSpawner _monsterSpawner;

    private void Awake()
    {
        _monsterSpawner = FindObjectOfType<MonsterSpawner>();
    }

    private void OnEnable()
    {
        StateManager.OnEnterInGameState += EnterInGame;
        Monster.OnDieMonster += ReceiveDyingMonster;
    }

    private void OnDisable()
    {
        StateManager.OnEnterInGameState -= EnterInGame;
        Monster.OnDieMonster -= ReceiveDyingMonster;
    }


    private void ReceiveDyingMonster()
    {
        CurrentCost++;
        MonsterCount--;
    }

    private void EnterInGame()
    {
        WaveCount = 0;
        CurrentCost = 10;
        StartCoroutine(StartStage(DataManager.GetStageData(1, 1)));
    }

    private IEnumerator StartStage(StageData data)
    {
        if (WaveCount < data.WaveCount)
        {
            yield return new WaitForSeconds(data.SpawnTimeList[WaveCount]);
            MonsterCount += data.MonsterCountList[WaveCount];
            _monsterSpawner.SpawnMonster(data.MonsterIdList[WaveCount], data.MonsterCountList[WaveCount]);
            WaveCount++;
            StartCoroutine(StartStage(data));
        }
    }
}
