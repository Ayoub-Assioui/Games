using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barsetactive : MonoBehaviour,ICollectable
{
    public GameObject bar; // Drag the background game object here in the inspector

    public void Collect()
    {

        bar.SetActive(true);


    }
}
