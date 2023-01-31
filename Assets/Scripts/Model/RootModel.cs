using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootModel : BaseManager<RootModel>
{
    //生长速度
    public float GrowSpeed = 1;
    //最低生长渡
    public float MinGrowSpeed = 0.5f;
    //最高生长渡
    public float MaxGrowSpeed = 10f;
    //水分
    public float WaterRemain = 100;
    //最大水分
    public float MaxWaterRemain = 100;
}
