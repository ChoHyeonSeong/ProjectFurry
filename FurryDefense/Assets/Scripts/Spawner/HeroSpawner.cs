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
    private HeroZone _heroZone;
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

    public void SetHeroZone(HeroZone zone)
    {
        if(zone == null)
        {
            _spawnedHero.HideTargetMonsterZone();
        }
        else
        {
            _spawnedHero.CalculrateAttackRange(zone);
            _spawnedHero.ShowTargetMonsterZone();
        }
        _heroZone = zone;
    }

    public void TryLandingHero()
    {
        if (_heroZone == null)
        {
            Destroy(_spawnedHero.gameObject);
        }
        else
        {
            _landingBtn.SetActive(false);
            _spawnedHero.MyZone = _heroZone;
            _spawnedHero.LandHero(_heroIndex);
            _heroZone.IsStandingHero = true;
        }
        _heroIndex = -1;
        _spawnedHero = null;
        _landingBtn = null;
        _heroZone = null;
        IsSpawnedHero = false;
    }

    private void Update()
    {
        if (_spawnedHero != null)
        {
            _spawnedHero.transform.position = GetSpawnedHeroPosition();
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
