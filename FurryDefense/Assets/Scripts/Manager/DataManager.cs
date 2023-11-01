using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class DataManager
{
    private static Dictionary<int, StageData> _stageDataDict;

    public static void LoadUserData(Action loadingCallback)
    {
        LoadStageData();
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

    public static StageData GetStageData(int mainStage, int subStage)
    {
        return _stageDataDict[(mainStage * 100) + subStage];
    }
}
