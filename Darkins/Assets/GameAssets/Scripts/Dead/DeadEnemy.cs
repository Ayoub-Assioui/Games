using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour, ICollisionHandler, IHitable
{
    public Animator animator;


    

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
        
    }
    public bool IsHit()
    {
        // Return whether the enemy has been hit by the projectile
        return isHit;
    }

    private void EDie()
    {
        animator.SetTrigger("Die");
        GetComponent<DeadBehaviour>().enabled = false;

    }

    // Hit by a Sword
    public void TakeHitS()
    {
        // Set isHit to true to indicate that the enemy has been hit by the projectile
        isHit = true;
        EDie();

    }

}
