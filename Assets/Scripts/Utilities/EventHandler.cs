using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : BaseManager<EventHandler>
{
    //当消耗水时触发事件
    public EasyEvent<float> WaterChange = new EasyEvent<float>();
    /// <summary>
    /// 输入正数为增加水，负数为消耗水
    /// </summary>
    /// <param name="cost">消耗数量</param>
    public void CallUpWaterChange(float cost)
    {
        WaterChange?.Trigger(cost);
        var model = RootModel.GetInstance();
        model.WaterRemain = Mathf.Clamp(model.WaterRemain + cost, 0, model.MaxWaterRemain);
    }
}
