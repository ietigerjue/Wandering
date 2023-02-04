using System.Drawing;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Typing : MonoBehaviour
{
    public Text dialogue;
    // Start is called before the first frame update
    void Start()
    {
        var se1 = DOTween.Sequence();
        se1.Append(dialogue.DOColor(UnityEngine.Color.grey,1));
    }

    void OnEnable()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
