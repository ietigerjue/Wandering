using System.Net.WebSockets;
using System.Net.Mime;
using System.Security.Principal;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindows : MonoBehaviour
{
     [SerializeField] GameObject window;
     [SerializeField] GameObject window1;
     [SerializeField] AudioSource click;
     public void OpenWindow()
     {
        click.Play();
        window.SetActive(true);
     }

     public void CloseWindow()
     {
      click.Play();
        window.SetActive(false);
     }
      public void OpenWindow1()
   {
      click.Play();
      window1.SetActive(true);
   }
   public void CloseWindow1()
{
   click.Play();
   window1.SetActive(false);
}

     

     public void QuitGame () 
     {
        Application.Quit();
     }



    // Start is called before the first frame update





}
