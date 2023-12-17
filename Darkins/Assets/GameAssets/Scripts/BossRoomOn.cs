using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomOn : MonoBehaviour
{
    public bosswall bosswall; // Assign the door object in the Inspector
   

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the object that entered the trigger is a box
        if (collider.gameObject.tag == "Player")
        {
            bosswall.wallon();
        }
        if (collider.gameObject.tag == "Shadow")
        {
            bosswall.wallon();
        }
        if (collider.gameObject.tag == "ZombieP")
        {
            bosswall.wallon();
        }
        if (collider.gameObject.tag == "GhostP")
        {
            bosswall.wallon();
        }
    }

   

    
}
