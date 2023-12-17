using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartM : MonoBehaviour
{

    //public ISScript isscript;

    // Start is called before the first frame update
    void Start()
    {

        //isscript.LoadFull();
        AudioManager.instance.Play("SpaceLevel");
        AudioManager.instance.Stop("MainMenu");
        AudioManager.instance.Stop("LavaLevel");
        AudioManager.instance.Stop("CrystalPeak");
    }

  

   
}
