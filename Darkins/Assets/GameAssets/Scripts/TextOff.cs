using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOff : MonoBehaviour,ICollectable
{
    public GameObject text; // Drag the background game object here in the inspector

    public void Collect()
    {

        text.SetActive(false);


    }
}