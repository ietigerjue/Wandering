using System.Net.Mime;
using System.Transactions;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pieces : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] float exitTime = 1.5f;
    public GameObject text;
    private WaitForSeconds waitforExit;
    // Start is called before the first frame update
    void Start()
    {
        waitforExit = new WaitForSeconds(exitTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Root")
        {
            StartCoroutine(nameof(SetActiveCoroutine));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Root")
        {
            panel.SetActive(false);
            text.SetActive(false);
        }
    }
    IEnumerator SetActiveCoroutine()
    {
         panel.SetActive(true);
         yield return waitforExit;
         text.SetActive(true);
    }


}
