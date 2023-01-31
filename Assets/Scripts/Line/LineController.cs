using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineController : MonoBehaviour
{
    //生长的速度
    private float CurSpeed => RootModel.GetInstance().GrowSpeed;

    //判断是否在生长
    private bool _isGrow;
    //当前的生长点
    private Vector2 _lastPos;
    //鼠标方向
    private Vector2 _growDir;
    //检测墙壁距离
    public float rayLength;
    //消耗值
    public float growWaterCost;
    //加速数值
    public float speedIncrement;
    //是否是加速状态
    private bool _isAccelerate;
    private void Start()
    {
        _lastPos = transform.position;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) OnGrowStart();
        if(Input.GetMouseButton(0)) OnGrow();
        if(Input.GetMouseButtonUp(0)) OnGrowEnd();
        if (Input.GetKeyDown(KeyCode.E))
        {
            _isAccelerate = true;
            StartCoroutine(Accelerate());
        }

        if (Input.GetKeyUp(KeyCode.E))
            _isAccelerate = false;
    }

    public void OnGrowStart()
    {
        _isGrow = true;
    }

    public void OnGrow()
    {
        var inputDir = ((Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - _lastPos).normalized;
        _growDir = Vector2.Lerp(_growDir, inputDir, 0.05f);
        var newPos = _lastPos + _growDir * CurSpeed * Time.deltaTime;
        var ray = Physics2D.Raycast(newPos, _growDir, rayLength, 1 << LayerMask.NameToLayer("Ground"));
        if (ray.collider)
        {
            Debug.Log(ray.collider.gameObject.name);
            _isGrow = false;
        }
        if (_isGrow)
        {
            transform.position = newPos;
            _lastPos = newPos;
            //TODO:消耗能量
            EventHandler.CallUpWaterChange(-growWaterCost);
        }
    }

    public void OnGrowEnd()
    {
        _isGrow = false;
    }

    IEnumerator Accelerate()
    {
        float addAmount = 0;
        var model = RootModel.GetInstance();
        while (_isAccelerate)
        {
            if (model.GrowSpeed < model.MaxGrowSpeed)
            {
                addAmount += speedIncrement;
                model.ExtraSpeed += speedIncrement;
            }
            yield return null;
        }

        RootModel.GetInstance().ExtraSpeed -= addAmount;
    }
}
