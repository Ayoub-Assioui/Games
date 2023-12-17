using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public Animator animator;

    public Animator fanimator;

    public GameObject LeverButton;

    public void Open()
    {
        animator.SetBool("On", true);
        AudioManager.instance.Play("Lever");
        fanimator.SetBool("FenceO", true);
        AudioManager.instance.Play("Gate");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LeverButton.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        LeverButton.SetActive(false);
    }
}
