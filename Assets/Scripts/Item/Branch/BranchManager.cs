using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchManager : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            BranchLineAlert();
    }

    public void BranchLineAlert()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var cols = Physics2D.OverlapPoint(pos, 1 << LayerMask.NameToLayer("Branch"));
        if (cols && cols.gameObject.GetComponent<BranchPoint>())
        {
            var branchPoint = cols.gameObject.GetComponent<BranchPoint>();
            branchPoint.AlertLine();
        }
    }
}
