using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HeroData
{
    public int HeroId { get; set; }

    public int PrefabIndex { get; set; }

    public int HeartPoint { get; set; }

    public int StrikingPower { get; set; }

    public int RequireCost { get; set; }

    public int TargetNum { get; set; }

    public float AttackSpeed { get; set; }

    public List<Vector2Int> AttackRange { get; set; }
}
