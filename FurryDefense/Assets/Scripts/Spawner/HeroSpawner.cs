using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    public bool IsSpawnedHero {  get; private set; }


    [SerializeField]
    private List<GameObject> _heroPrefabs;

    private GameObject _spawnedHero;
    private GameObject _heroZone;


    public void SpawnHero(int id, Vector3 spawnPos)
    {
        _spawnedHero = Instantiate(_heroPrefabs[id], spawnPos, Quaternion.identity, transform);
        IsSpawnedHero = true;
    }

    public void ChangeHeroZone(GameObject zone)
    {
        _heroZone = zone;
    }

    private void Update()
    {
        if (_spawnedHero != null && Input.touchCount > 0)
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
