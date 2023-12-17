using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartL : MonoBehaviour
{

    //public ISScript isscript;

    // Start is called before the first frame update
    void Start()
    {
        //isscript.LoadFull();
        AudioManager.instance.Play("LavaLevel");
        AudioManager.instance.Stop("MainMenu");
        AudioManager.instance.Stop("SpaceLevel");
        AudioManager.instance.Stop("CrystalPeak");
    }

 

    
}
