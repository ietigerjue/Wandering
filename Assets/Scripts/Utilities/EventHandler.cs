using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
    //当消耗水时触发事件
    public static EasyEvent<float> WaterChange = new EasyEvent<float>();
    /// <summary>
    /// 输入正数为增加水，负数为消耗水
    /// </summary>
    /// <param name="cost">消耗数量</param>
    public static void CallUpWaterChange(float cost)
    {
        var model = RootModel.GetInstance();
        model.WaterRemain = Mathf.Clamp(model.WaterRemain + cost, 0, model.MaxWaterRemain);
        // Debug.Log("当前水分：" + model.WaterRemain);
        WaterChange?.Trigger(cost);
    }
    //速度改变
    public static EasyEvent<float> SpeedChange = new EasyEvent<float>();

    public static void CallUpSpeedChange(float count)
    {
        var model = RootModel.GetInstance();
        model.CurSpeed = Mathf.Clamp(model.CurSpeed + count, model.MinGrowSpeed, model.MaxGrowSpeed);
        SpeedChange?.Trigger(count);
    }
}
