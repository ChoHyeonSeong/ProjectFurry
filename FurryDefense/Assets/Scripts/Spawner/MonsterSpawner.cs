using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    public static Action<Monster> OnSpawnMonster { get; set; }

    [SerializeField]
    private Monster _monsterPrefab;


    public void SpawnMonster(int monsterId, int monsterCount)
    {
        for (int i = 0; i < monsterCount; i++)
        {
            Monster monster = Instantiate(_monsterPrefab, transform);
            monster.ChangeMoveDirection(Random.insideUnitCircle.normalized);
            OnSpawnMonster(monster);
        }
    }
}
