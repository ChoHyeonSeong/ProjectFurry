using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterZone : MonoBehaviour
{
    public List<Monster> MonsterList { get; private set; }

    [SerializeField]
    private SpriteRenderer _sprite;

    private Color _orangeColor= new Color(1.0f, 0.5f, 0);

    private string _monsterTag = "Monster";

    public void ShowAttackRange()
    {
        _sprite.color = _orangeColor;
    }
    public void HideAttackRange()
    {
        _sprite.color = Color.white;
    }

    private void Awake()
    {
        MonsterList = new List<Monster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(_monsterTag))
        {
            MonsterList.Add(collision.GetComponent<Monster>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_monsterTag))
        {
            MonsterList.Remove(collision.GetComponent<Monster>());
        }
    }
}
