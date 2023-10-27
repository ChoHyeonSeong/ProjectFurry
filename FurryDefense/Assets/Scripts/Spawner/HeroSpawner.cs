using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    public bool IsSpawnedHero { get; private set; }


    [SerializeField]
    private List<Hero> _heroPrefabs;

    private Hero _spawnedHero;
    private GameObject _heroZone;
    private GameObject _landingBtn;
    private int _heroIndex;

    public void DestroySpawnedHero()
    {
        _spawnedHero = null;
        IsSpawnedHero = false;
    }

    public void SpawnHero(int index, Vector3 spawnPos, GameObject landingBtn)
    {
        _spawnedHero = Instantiate(_heroPrefabs[index], spawnPos, Quaternion.identity, transform);
        _heroIndex = index;
        _landingBtn = landingBtn;
        IsSpawnedHero = true;
    }

    public void ChangeHeroZone(GameObject zone)
    {
        _heroZone = zone;
    }

    private void Update()
    {
        if (_spawnedHero != null)
        {
            if (Input.touchCount > 0)
            {
                _spawnedHero.transform.position = GetSpawnedHeroPosition();
            }
            else if (Input.touchCount == 0)
            {
                if(_heroZone == null)
                {
                    Destroy(_spawnedHero.gameObject);
                }
                else
                {
                    _landingBtn.SetActive(false);
                    _spawnedHero.LandHero(_heroIndex);
                }
                _heroIndex = -1;
                _spawnedHero = null;
                _landingBtn = null;
                IsSpawnedHero = false;
            }
        }
    }

    private Vector3 GetSpawnedHeroPosition()
    {
        Vector3 heroPos;
        if (_heroZone == null)
        {
            heroPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            heroPos.z = 0;
        }
        else
        {
            heroPos = _heroZone.transform.position;
        }
        return heroPos;
    }
}
