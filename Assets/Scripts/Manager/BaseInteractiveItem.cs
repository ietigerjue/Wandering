using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ½»»¥»ùÀà
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class BaseInteractiveItem : MonoBehaviour
{
    public bool IsInteract = false;
    public BaseItem InteractiveItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 6)
        {
            InteractiveItem = collision.GetComponent<BaseItem>();
        }
        else
        {
            Interactfun();
        }
        if (InteractiveItem)
        {
            InteractEnter();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 6)
        {
            InteractiveItem = collision.GetComponent<BaseItem>();
            if (InteractiveItem != null)
                InteractExit();
        }
    }
    private void Update()
    {
        if(IsInteract) Interacting();
    }
    public virtual void InteractEnter()
    {
        IsInteract = true;
    }
    public virtual void Interacting()
    {

    }
    public virtual void InteractExit()
    {
        InteractiveItem = null;
        IsInteract = false;
    }
    public virtual void Interactfun()
    {

    }
}
