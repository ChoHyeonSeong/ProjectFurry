using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterZone : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _sprite;

    private Color _orangeColor= new Color(1.0f, 0.5f, 0);

    private List<Monster> _monsters = new List<Monster>();
    private string _monsterTag = "Monster";

    public void ShowAttackRange()
    {
        _sprite.color = _orangeColor;
    }
    public void HideAttackRange()
    {
        _sprite.color = Color.white;
    }

    public void AttackMonster(int damage)
    {
        for(int i=0; i< _monsters.Count; i++)
        {
            _monsters[i].PlusHeartPoint(-damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(_monsterTag))
        {
            _monsters.Add(collision.GetComponent<Monster>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_monsterTag))
        {
            _monsters.Remove(collision.GetComponent<Monster>());
        }
    }
}
