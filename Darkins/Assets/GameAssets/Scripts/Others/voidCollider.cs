using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voidCollider : MonoBehaviour,ICollisionHandler
{
    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "DeathArea" && other.tag == "Player")
        {
            other.GetComponent<Player>().Refrences.gameover.GameOver();
           
        }
        if (colliderName == "DeathArea" && other.tag == "Shadow")
        {
            other.GetComponent<Shadow>().Refrences.gameover.GameOver();
        }
        if (colliderName == "DeathArea" && other.tag == "ZombieP")
        {
            other.GetComponent<Zombie>().Refrences.gameover.GameOver();
        }
    }
}
