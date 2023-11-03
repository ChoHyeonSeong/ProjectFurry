using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTimeBar : MonoBehaviour
{
    [SerializeField]
    private Image _fill;
    private float _currentTime;
    private float _maxTime;

    private void Awake()
    {   
        _currentTime = -1;
        InGameHandler.OnSetSpawnTime += SetSpawnTime;
    }

    private void OnDestroy()
    {
        InGameHandler.OnSetSpawnTime -= SetSpawnTime;
    }

    private void Update()
    {
        if(_currentTime > 0)
        {
            _fill.fillAmount = _currentTime / _maxTime;
            _currentTime -= Time.deltaTime;
        }
    }

    private void SetSpawnTime(float time)
    {
        _maxTime = time;
        _currentTime = _maxTime;    
    }
}
