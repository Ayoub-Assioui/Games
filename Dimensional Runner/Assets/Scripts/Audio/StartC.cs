using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartC : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
        AudioManager.instance.Play("CrystalPeak");
        AudioManager.instance.Stop("LavaLevel");
        AudioManager.instance.Stop("MainMenu");
        AudioManager.instance.Stop("SpaceLevel");
    }

   
  
}
