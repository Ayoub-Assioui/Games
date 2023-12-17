using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDamage : MonoBehaviour, ICollisionHandler, ICollisionTemp
{
    public float interval = 5f;// time
    public GameObject player;
    public GameObject shadow;

    private bool isCollidingWithPoison = false;

    private void Start()
    {
        isCollidingWithPoison = false;
    }
    // Enter the collision
    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "PoisonArea" && other.tag == "Player")
        {
            isCollidingWithPoison = true;
            StartCoroutine(TakeHitCoroutine());
        }
        if (colliderName == "PoisonArea" && other.tag == "Shadow")
        {
            isCollidingWithPoison = true;
            StartCoroutine(STakeHitCoroutine());
        }
    }
    // Take Hit every 5 seconds
    private IEnumerator TakeHitCoroutine()
    {
        while (isCollidingWithPoison)
        {
            player.GetComponent<Player>().Actions.TakeHit();
            yield return new WaitForSeconds(interval);
        }
      
    }
    private IEnumerator STakeHitCoroutine()
    {
       
        while (isCollidingWithPoison)
        {
            shadow.GetComponent<Shadow>().Actions.TakeHit();
            yield return new WaitForSeconds(interval);
        }
    }

    //Exit the collision
    public void CollisionExit(string colliderName, GameObject other)
    {
        if (colliderName == "PoisonArea" && other.tag == "Player")
        {
            isCollidingWithPoison = false;
        }
        if (colliderName == "PoisonArea" && other.tag == "Shadow")
        {
            isCollidingWithPoison = false;
        }
    }

}
