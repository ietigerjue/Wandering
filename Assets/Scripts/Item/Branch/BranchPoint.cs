using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchPoint : BaseInter
{
    private LineManager _lineManager;
    private bool _isBranch;
    private void Start()
    {
        _lineManager = GetComponent<LineManager>();
        addEvent(() =>
        {
            
        });
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Root") && !_isBranch)
        {
            Execution();
            _lineManager.GenerateLine(transform.position, col.gameObject.GetComponent<LineController>());
            _isBranch = true;
            Destroy(gameObject);
        }
    }

    public void AlertLine()
    {
        _lineManager.AlertLine();
    }
}
