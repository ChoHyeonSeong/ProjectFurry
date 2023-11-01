using System;
using System.Collections.Generic;

[Serializable]
public class StageData
{
    public int StageId { get; set; }
    public int WaveCount { get; set; }
    public List<int> MonsterIdList { get; set; }
    public List<int> MonsterCountList { get; set; }
    public List<float> SpawnTimeList { get; set; }
}
