using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    
        public bool doorIsOpen = false;

        public void OpenDoor()
        {
            // Change door sprite or position to make it appear as if the door is opening
            doorIsOpen = true;
            animator.Play("Open-Door");
        }

        public void CloseDoor()
        {
            // Change door sprite or position to make it appear as if the door is closing
            doorIsOpen = false;
             animator.Play("Close-Door");
    }
    }
