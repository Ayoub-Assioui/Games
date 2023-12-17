using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WbotBehav : MonoBehaviour
{

    public Animator animator;

    public Animator panimator;

    public GameObject uiwater;

    public GameObject autoattack;

    private bool hasAcceptedWater = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.tag == "Player" && !hasAcceptedWater)
        {
            animator.SetBool("wakeup", true);
            uiwater.SetActive(true);
        }
        if (other.gameObject.tag == "Player" && hasAcceptedWater)
        {
            animator.SetBool("wakeup", true);
            
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("wakeup", false);
            uiwater.SetActive(false);
        }
    }

    public void AcceptWater()
    {
        panimator.Play("WPowerup");
        autoattack.SetActive(true);
        hasAcceptedWater = true;
    }
}
