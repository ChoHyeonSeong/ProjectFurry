using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterZone : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _sprite;

    public void ShowAttackRange()
    {
        _sprite.color = new Color(1.0f, 0.5f, 0);
    }
    public void HideAttackRange()
    {
        _sprite.color = Color.white;
    }
}
