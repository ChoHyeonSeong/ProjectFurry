using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MonsterData
{
    public int MonsterId { get; set; }

    public int HeartPoint { get; set; }

    public int StrikingPower { get; set; }

    public int DropCost { get; set; }

    public float MoveSpeed { get; set; }
}
