using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour, ICollisionHandler, IHitable
{
    public Animator animator;


   // public GameObject ZombieButton;

    // Flag to indicate if the enemy has been hit by the projectile
    private bool isHit = false;



    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "DamageArea" && other.tag == "Player")
        {
            other.GetComponent<Player>().Actions.TakeHit();
        }
        if (colliderName == "DamageArea" && other.tag == "Shadow")
        {
            other.GetComponent<Shadow>().Actions.TakeHit();
        }
        if (colliderName == "DamageArea" && other.tag == "ZombieP")
        {
            other.GetComponent<Zombie>().Actions.TakeHit();
        }
    }

    public void TakeHit()
    {
        // Set isHit to true to indicate that the enemy has been hit by the projectile
        isHit = true;
        EDie();
        //ZombieButton.SetActive(true);
    }
    public bool IsHit()
    {
        // Return whether the enemy has been hit by the projectile
        return isHit;
    }

    private void EDie()
    {
        animator.SetTrigger("die");
        GetComponent<Ghostbehaviour>().enabled = false;

    }

    // Hit by a Sword
    public void TakeHitS()
    {
        // Set isHit to true to indicate that the enemy has been hit by the projectile
        isHit = true;
        EDie();

    }
}
