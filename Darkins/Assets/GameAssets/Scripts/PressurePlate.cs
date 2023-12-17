using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Door door; // Assign the door object in the Inspector
    public bool boxOnPlate = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the object that entered the trigger is a box
        if (collider.gameObject.tag == "Box")
        {
            boxOnPlate = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // Check if the object that exited the trigger is a box
        if (collider.gameObject.tag == "Box")
        {
            boxOnPlate = false;
        }
    }

    void Update()
    {
        if (boxOnPlate)
        {
            door.OpenDoor();
        }
        else
        {
            door.CloseDoor();
        }
    }
}
