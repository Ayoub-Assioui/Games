using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure : MonoBehaviour
{
    public Animator animator;

    public Animator fanimator;



    
           
        

    




    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            animator.SetBool("PressureOn", true);


            fanimator.SetBool("FenceOn", true);
            

        }
    }
  

    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            animator.SetBool("PressureOn", false);
            fanimator.SetBool("FenceOn", false);
        }
    }
   
}
