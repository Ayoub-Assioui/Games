using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    // Drag and drop the door sprites onto these fields in the Inspector window
    public Transform door1;
    public Transform door2;

    // Update is called once per frame
    void Update()
    {
        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Calculate the distance to each door
            float distanceToDoor1 = Vector2.Distance(transform.position, door1.position);
            float distanceToDoor2 = Vector2.Distance(transform.position, door2.position);

            // Choose the door that is closest
            if (distanceToDoor1 < distanceToDoor2)
            {
                transform.position = door2.position;
            }
            else
            {
                transform.position = door1.position;
            }
        }
    }
}