using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour,ICollisionHandler
{
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
}
