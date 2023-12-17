using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosswall : MonoBehaviour
{
    public Animator animator;

    public bool wallIsOn = false;

    public void wallon()
    {
        // Change door sprite or position to make it appear as if the door is opening
        wallIsOn = true;
        animator.Play("WallOn");
    }

    
}
