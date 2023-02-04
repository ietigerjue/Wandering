using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : BaseInter
{
    public float waterAmount;
    public float speedAmount;
    private void OnEnable()
    {
        addEvent(() =>
        {
            EventHandler.CallUpWaterChange(waterAmount);
            EventHandler.CallUpSpeedChange(speedAmount);
            Destroy(gameObject);
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
