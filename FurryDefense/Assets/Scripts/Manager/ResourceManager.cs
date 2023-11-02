using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ResourceManager
{
    private static List<Hero> _heroPrefabList;
    private static List<Monster> _monsterPrefabList;

    public static void LoadHeroResource()
    {
        _heroPrefabList = Resources.LoadAll<Hero>("Prefabs/Character/Hero").ToList();
    }

    public static void LoadMonsterResource()
    {
        _monsterPrefabList = Resources.LoadAll<Monster>("Prefabs/Character/Monster").ToList();
    }

    public static Hero GetHeroPrefab(int prefabIndex)
    {
        return _heroPrefabList[prefabIndex];
    }
    public static Monster GetMonsterPrefab(int prefabIndex)
    {
        return _monsterPrefabList[prefabIndex];
    }
}
