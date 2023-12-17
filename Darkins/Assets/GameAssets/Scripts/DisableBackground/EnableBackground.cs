using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBackground : MonoBehaviour,ICollectable
{
    public GameObject background; // Drag the background game object here in the inspector

    public void Collect()
    {

        background.SetActive(true);


    }
}