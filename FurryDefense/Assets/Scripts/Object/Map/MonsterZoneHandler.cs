using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterZoneHandler : MonoBehaviour
{
    private List<List<MonsterZone>> _monsterZoneList;

    private void Awake()
    {
        _monsterZoneList = new List<List<MonsterZone>>();
        for (int i = 0; i < 5; i++)
        {
            _monsterZoneList.Add(new List<MonsterZone>());
            for (int j = 0; j < 5; j++)
            {
                _monsterZoneList[i].Add(null);
            }
        }

        var monsterZoneList = GetComponentsInChildren<MonsterZone>();

        for (int i = 0; i < monsterZoneList.Length; i++)
        {
            _monsterZoneList[(i / 3) + 1][(i % 3) + 1] = monsterZoneList[i];
        }
    }

    public List<MonsterZone> GetTargetMonsterZone(List<Vector2Int> attackRange)
    {
        for(int i=0;i<_monsterZoneList.Count;i++)
        {
            for(int j = 0; j < _monsterZoneList[i].Count;j++)
            {
                Debug.Log($"({j},{i}) == {_monsterZoneList[i][j]}");
            }
        }

        List<MonsterZone> target = new List<MonsterZone>();
        MonsterZone zone;
        for (int i = 0; i < attackRange.Count; i++)
        {
            Debug.Log($"{attackRange[i]} == AttackRange");
            zone = _monsterZoneList[attackRange[i].y][attackRange[i].x];
            if (zone != null)
            {
                target.Add(zone);
            }
        }
        return target;
    }
}
