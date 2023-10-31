using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartPointBar : MonoBehaviour
{
    private Monster _monster;
    [SerializeField]
    private Image _fill;
    private Vector3 _onHeadPos = new Vector3(0, 50, 0);
    private float _fillAmount;

    private void Awake()
    {
        _fillAmount = 1;
    }

    public void SetMonster(Monster monster)
    {
        _monster = monster;
        _monster.OnPlusHeartPoint += UpdateBar;
    }

    public void UpdateBar()
    {
        _fill.fillAmount = _fillAmount = (float)_monster.CurrentHP / _monster.MaxHP;
        Debug.Log(_fillAmount);
    }

    private void LateUpdate()
    {
        if (_fillAmount <= 0)
        {
            Destroy(gameObject);
        }
        transform.position = Camera.main.WorldToScreenPoint(_monster.transform.position) + _onHeadPos;
    }
}
