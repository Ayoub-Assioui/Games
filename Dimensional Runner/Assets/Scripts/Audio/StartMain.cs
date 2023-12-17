using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("MainMenu");
        AudioManager.instance.Stop("SpaceLevel");
        AudioManager.instance.Stop("LavaLevel");
        AudioManager.instance.Stop("CrystalPeak");
    }

   
}
