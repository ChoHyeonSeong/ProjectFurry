using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DataManager.LoadUserData(GameStart);
    }

    private void Start()
    {
        StateManager.StartState();
    }


    private void GameStart()
    {
        DataManager.LoadStageData();
        DataManager.LoadMonsterData();
        DataManager.LoadHeroData();
        ResourceManager.LoadHeroResource();
        ResourceManager.LoadMonsterResource();
    }
}
