using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject objectToControl;
    public PingPong scriptToControl;
    public Animator leverAnimator;
    public string onTrigger;
    public string offTrigger;
    

    private bool isOn = false;

    private void Update()
    {
        // Check if the toggle key is pressed
        if (Input.GetKeyDown(KeyCode.G))
        {
            // Toggle the state of the lever
            isOn = !isOn;
        }

        // Check if the lever is on or off
        if (isOn)
        {
            // Enable the script on the object
            scriptToControl.enabled = true;

            // Set the onTrigger animation trigger
            leverAnimator.SetTrigger(onTrigger);
        }
        else
        {
            // Disable the script on the object
            scriptToControl.enabled = false;

            // Set the offTrigger animation trigger
            leverAnimator.SetTrigger(offTrigger);
        }
    }
}