using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public LineController linePfb;

    private List<LineController> _lineList = new List<LineController>();

    private int _curLineIndex;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AlertLine();
        }
        
    }

    public void GenerateLine(Vector2 initPos, LineController origin)
    {
        _lineList.Add(origin);
        var line = Instantiate(linePfb, initPos, Quaternion.identity, GameObject.FindWithTag("Line").transform);
        _lineList.Add(line);
        line.enabled = false;
    }

    public void AlertLine()
    {
        if(_lineList.Count == 0)
            return;
        _curLineIndex = (_curLineIndex + 1) % _lineList.Count;
        for (int i = 0; i < _lineList.Count; i++)
        {
            if (i == _curLineIndex)
                _lineList[i].enabled = true;
            else
            {
                _lineList[i].enabled = false;
            }
        }
    }
}
