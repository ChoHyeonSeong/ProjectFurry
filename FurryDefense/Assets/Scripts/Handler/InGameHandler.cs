using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameHandler : MonoBehaviour
{
    public static Action<int> OnSetCurrentCost { get; set; }
    public static Action<int> OnSetGameSpeed { get; set; }
    public static Action<int, int> OnSetWaveCount { get; set; }
    public static Action<int> OnSetMonsterCount { get; set; }

    public static Action <float> OnSetSpawnTime { get; set; }
    public static Action<List<int>> OnSetHeroFormation { get; set; }

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
            OnSetWaveCount(_waveCount, _maxWave);
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
    private int _maxWave;

    private MonsterSpawner _monsterSpawner;
    private FormationHandler _formationHandler;

    private void Awake()
    {
        _monsterSpawner = FindObjectOfType<MonsterSpawner>();
        _formationHandler = FindObjectOfType<FormationHandler>();
    }

    private void OnEnable()
    {
        StateManager.OnEnterInGameState += EnterInGame;
        Monster.OnDieMonster += ReceiveDyingMonster;
        HeroSpawner.OnSuccessLandingHero += ReceiveLandingHero;
    }

    private void OnDisable()
    {
        StateManager.OnEnterInGameState -= EnterInGame;
        Monster.OnDieMonster -= ReceiveDyingMonster;
        HeroSpawner.OnSuccessLandingHero -= ReceiveLandingHero;
    }


    private void ReceiveDyingMonster(Monster monster)
    {
        CurrentCost += monster.DropCost;
        MonsterCount--;
    }

    private void ReceiveLandingHero(int heroId)
    {
        CurrentCost -= DataManager.GetHeroData(heroId).RequireCost;
    }

    private void EnterInGame()
    {
        OnSetHeroFormation(_formationHandler.HeroIdList);
        StageData stageData = DataManager.GetStageData(1, 1);
        _maxWave = stageData.WaveCount;
        WaveCount = 0;
        CurrentCost = 10;
        GameSpeed = 1;
        MonsterCount = 0;
        StartCoroutine(StartStage(stageData));
    }

    private IEnumerator StartStage(StageData data)
    {
        if (WaveCount < data.WaveCount)
        {
            OnSetSpawnTime(data.SpawnTimeList[WaveCount]);
            yield return new WaitForSeconds(data.SpawnTimeList[WaveCount]);
            MonsterCount += data.MonsterCountList[WaveCount];
            _monsterSpawner.SpawnMonster(data.MonsterIdList[WaveCount], data.MonsterCountList[WaveCount]);
            WaveCount++;
            StartCoroutine(StartStage(data));
        }
    }
}
