using System.Xml.Schema;
using System.Xml;
using System.Threading;
using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPort : SingletonMono<ViewPort>
{
    float minX;
    float maxX;
    float maxY;
    float minY;
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main;

        UnityEngine.Vector2 bottomleft = mainCamera.ViewportToWorldPoint(new UnityEngine.Vector3(0f , 0f));
        UnityEngine.Vector2 topright = mainCamera.ViewportToWorldPoint(new UnityEngine.Vector3(1f , 1f));

        minX = bottomleft.x;
        maxX = bottomleft.y;
        minY = topright.x;
        maxY = topright.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public UnityEngine.Vector3 PlayerMoveablePosition(UnityEngine.Vector3 playerposition)
    {
        UnityEngine.Vector3 position = UnityEngine.Vector3.zero;

        position.x = Mathf.Clamp(playerposition.x,minX,maxX);
        position.y = Mathf.Clamp(playerposition.y,minY,maxY);
        return position;
    }
}
