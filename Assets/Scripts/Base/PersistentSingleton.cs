using System.Security.AccessControl;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T : UnityEngine.Component
{
    public static T Instance{get; private set;}

    protected virtual void Awake()
    {
        if(Instance == null)
        {
            Instance = this as T;
        }
        else if(Instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
   
   
   
   

   
   
   
   
   
}
