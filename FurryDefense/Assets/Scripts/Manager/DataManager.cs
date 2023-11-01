using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class DataManager
{
    private static Dictionary<int, StageData> _stageDataDict;
    private static Dictionary<int, MonsterData> _monsterDataDict;

    public static void LoadUserData(Action loadingCallback)
    {
        LoadStageData();
        LoadMonsterData();
        loadingCallback();
    }

    private static void LoadStageData()
    {
        _stageDataDict = new Dictionary<int, StageData>();
        StageData stageData = new StageData();
        stageData.StageId = 101;
        stageData.WaveCount = 1;
        stageData.MonsterIdList = new List<int>() { 0 };
        stageData.MonsterCountList = new List<int>() { 40 };
        stageData.SpawnTimeList = new List<float>() { 1.5f };
        _stageDataDict[stageData.StageId] = stageData;
    }

    private static void LoadMonsterData()
    {
        _monsterDataDict = new Dictionary<int, MonsterData>();
        MonsterData monsterData = new MonsterData();
        monsterData.MonsterId = 0;
        monsterData.PrefabIndex = 0;
        monsterData.HeartPoint = 10;
        monsterData.StrikingPower = 1;
        monsterData.DropCost = 1;
        monsterData.MoveSpeed = 1;
        _monsterDataDict[monsterData.MonsterId] = monsterData;
    }

    public static StageData GetStageData(int mainStage, int subStage)
    {
        return _stageDataDict[(mainStage * 100) + subStage];
    }

    public static MonsterData GetMonsterData(int monsterId)
    {
        return _monsterDataDict[monsterId];
    }
}
