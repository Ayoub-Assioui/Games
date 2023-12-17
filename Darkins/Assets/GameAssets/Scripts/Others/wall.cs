using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour,ICollectable
{

    public GameObject phys; // Drag the background game object here in the inspector

    public void Collect()
    {

        phys.SetActive(true);


    }
}