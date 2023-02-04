using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBody : MonoBehaviour
{
   public void Destroythis(){
    Destroy(gameObject);
   //GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
   }
}
