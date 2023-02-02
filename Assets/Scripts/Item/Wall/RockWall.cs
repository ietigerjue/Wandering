using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWall : MonoBehaviour
{
    public float speedThreshold;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Root"))
        {
            if (RootModel.GetInstance().GrowSpeed > speedThreshold)
            {
                Destroy(gameObject);
            }
        }
    }
}
