using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMoon : MonoBehaviour,ICollectable
{
   
        public GameObject bloodmoon; // Drag the background game object here in the inspector


        public GameObject background;

    public void Collect()
        {

            bloodmoon.SetActive(true);

            background.SetActive(false);


        }
    }
    