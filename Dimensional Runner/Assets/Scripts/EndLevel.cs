using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndLevel : MonoBehaviour
{
    //public ISScript isscript;

    public UiManager uimanager;


    private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.transform.tag == "Player")
        {

            uimanager.CompleteLevel();

            

            //isscript.LoadFull();
        }
     }

   

}

