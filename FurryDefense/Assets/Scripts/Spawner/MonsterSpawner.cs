using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private Monster _monsterPrefab;

    private void Start()
    {
        SpawnMonster();
    }

    public void SpawnMonster()
    {
        for(int i=0;i<40;i++)
        {
            Monster monster = Instantiate(_monsterPrefab, transform);
            monster.ChangeMoveDirection(Random.insideUnitCircle.normalized);
        }
    }
}
