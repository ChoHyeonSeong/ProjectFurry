using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HeroData
{
    public int HeroCost { get; set; }

    public int AttackDamage { get; set; }

    public int AttackNum { get; set; }

    public float AttackSpeed { get; set; }

    public List<Vector2Int> AttackRange { get; set; }
}
