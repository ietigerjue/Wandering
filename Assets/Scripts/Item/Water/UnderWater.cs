using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : BaseInter
{
    public float waterAmount;
    private void OnEnable()
    {
        addEvent(() =>
        {
            EventHandler.GetInstance().CallUpWaterChange(waterAmount);
        });
    }

    private void OnDisable()
    {
        clearEvent = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Root"))
            Execution();
    }
}
