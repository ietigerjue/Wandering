using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutPoint : BaseInter
{
    private void Start() {
        addEvent(()=>{
            LineController.GetInstance().CutLenth(100);
        Destroy(gameObject);
        });
    }
}
