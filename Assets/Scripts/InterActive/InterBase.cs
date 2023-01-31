using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InterBase : MonoBehaviour
{
    public UnityEvent unityEvent;
    public bool clearEvent;
    public int Index=0;
    //触发物体调用此方法来执行
    public void Execution()
    {
        unityEvent.Invoke();
        if (clearEvent)
        {
            unityEvent.RemoveAllListeners();
        }
    }
    //继承该类的物体用此方法添加触发事件
    public void addEvent(UnityAction action)
    {
        unityEvent.AddListener(action);
    }
}
