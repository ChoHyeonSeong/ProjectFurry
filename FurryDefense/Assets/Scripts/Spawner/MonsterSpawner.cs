using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    public static Action<Monster> OnSpawnMonster { get; set; }

    private List<Monster> _monsterPrefabList;

    private void Awake()
    {
        _monsterPrefabList = Resources.LoadAll<Monster>("Prefabs").ToList();
    }

    public void SpawnMonster(int monsterId, int monsterCount)
    {
        MonsterData data = DataManager.GetMonsterData(monsterId);
        for (int i = 0; i < monsterCount; i++)
        {
            Monster monster = Instantiate(_monsterPrefabList[data.PrefabIndex], transform);
            monster.InitMonster(data, Random.insideUnitCircle.normalized);
            OnSpawnMonster(monster);
        }
    }
}
