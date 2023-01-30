using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//触发基类，继承此类的物体通过addEvent添加具体的触发事件，通过Execution进行触发，至于具体的触发机制由具体的触发物决定
public class BaseInter : MonoBehaviour
{
    public UnityEvent unityEvent;
    public bool clearEvent;
    public int Index=0;
    public void Execution()
    {
        unityEvent.Invoke();
        if (clearEvent)
        {
            unityEvent.RemoveAllListeners();
        }
    }
    public void addEvent(UnityAction action)
    {
        unityEvent.AddListener(action);
    }
}
