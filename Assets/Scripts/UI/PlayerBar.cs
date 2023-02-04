using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{
    private Canvas _canvas;
    //延迟比例
    public float delayRate = 0.02f;
    //当前血量
    public Image hpBar;
    //血量延迟效果
    public Image hpBarDelay;

    private Coroutine _hpDelay;
    //当前的血量条
    private float _curAmount = 1;
    //目标血量条
    private float _targetAmount = 1;

    private bool _isDelay;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.worldCamera = Camera.main;
    }

    private void OnEnable()
    {
        //注册事件
        EventHandler.WaterChange.Register(OnWaterChange).UnRegisterWhenGameObjectDestroyed(this.gameObject);
    }

    IEnumerator HpDelay()
    {
        _isDelay = true;
        while (_curAmount - _targetAmount > 0.005f)
        {
            Debug.Log(_curAmount);
            _curAmount =  Mathf.Lerp(_curAmount, _targetAmount, delayRate);
            hpBarDelay.fillAmount = _curAmount;

            yield return null;
        }
        
        hpBarDelay.fillAmount = _targetAmount;
        _curAmount = _targetAmount;
        _isDelay = false;
    }

    public void OnWaterChange(float cost)
    {
        _targetAmount = RootModel.GetInstance().WaterRemain / RootModel.GetInstance().MaxWaterRemain;

        if (_targetAmount > _curAmount)
        {
            hpBar.fillAmount = _targetAmount;
            hpBarDelay.fillAmount = _targetAmount;
        }

        if (_targetAmount < _curAmount)
        {
            hpBar.fillAmount = _targetAmount;
            if (!_isDelay)
            {
                _hpDelay = StartCoroutine(HpDelay());
            }
        }
    }
    
}
