using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineController : SingletonMono<LineController>
{
    //生长的速度
    private float CurSpeed => RootModel.GetInstance().GrowSpeed;
    public GameObject body;
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
    public List<Transform> reStep = new List<Transform>();
    float length = 0;
    private void Start()
    {
        _lastPos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BaseInter>())
        {
            other.GetComponent<BaseInter>().Execution();
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) OnGrowStart();
        if (Input.GetMouseButton(0)) OnGrow();
        if (Input.GetMouseButtonUp(0)) OnGrowEnd();
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
    public void CutLenth(int length)
    {
        Debug.Log(reStep.Count);

        _isGrow = false;
        if (reStep.Count - length - 1 < 0)
        {
            List<Transform> _Clearing = new List<Transform>();
            int c = reStep.Count;
            for (int i = 1; i < c; i++)
            {
                _Clearing.Add(reStep[i]);

            }
            for (int i = 1; i < c-1; i++)
            {
                reStep.RemoveAt(1);

            }
            int _c = _Clearing.Count;
            for (int i = 1; i < _c; i++)
            {
                Debug.Log(_Clearing[i].name);
                Destroy(_Clearing[i].gameObject);

            }
            transform.position = reStep[0].position;
            _lastPos = transform.position;

            return;

        }
        int k = reStep.Count;
        List<Transform> Clearing = new List<Transform>();

        for (int i = k - 1; i > k - length - 1; i--)
        {
            Clearing.Add(reStep[i]);
        }
        for (int i = k - 1; i > k - length - 1; i--)
        {
            reStep.RemoveAt(k-length-1);
        }
        int _k = Clearing.Count;
        for (int i = 1; i < _k; i++)
        {

            Clearing[i].GetComponent<LineBody>().Destroythis();
            //Clearing[i].gameObject.SetActive(false);


        }
        transform.position = reStep[k - length-1].position;
        _lastPos = transform.position;

        Debug.Log(reStep.Count);


    }
    public void OnGrow()
    {
        var inputDir = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - _lastPos).normalized;
        _growDir = Vector2.Lerp(_growDir, inputDir, 0.05f);
        var distance = _growDir * CurSpeed * Time.deltaTime;
        var newPos = _lastPos + distance;
        length += Vector2.Distance(_lastPos, newPos);

        var ray = Physics2D.Raycast(newPos, _growDir, rayLength, 1 << LayerMask.NameToLayer("Ground"));
        if (ray.collider)
        {
            Debug.Log(ray.collider.gameObject.name);
            _isGrow = false;
        }
        if (_isGrow)
        {

            var bodys = Instantiate(body).transform;
            bodys.position = _lastPos;
            reStep.Add(bodys);

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
