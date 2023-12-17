using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour,ICollisionHandler
{
    public Player player;

    public Shadow shadow;

    public Zombie zombie;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.Actions.KBConter = player.Actions.KBTotalTime;
            if (collision.transform.position.x > transform.position.x)
            {
                player.Actions.KnockFromRight = false;
            }
            if (collision.transform.position.x <= transform.position.x)
            {
                player.Actions.KnockFromRight = true;
            }
        }

        if (collision.gameObject.CompareTag("Shadow"))
        {
            shadow.Actions.KBConter = shadow.Actions.KBTotalTime;
            if (collision.transform.position.x > transform.position.x)
            {
                player.Actions.KnockFromRight = false;
            }
            if (collision.transform.position.x <= transform.position.x)
            {
                player.Actions.KnockFromRight = true;
            }
        }

        if (collision.gameObject.CompareTag("ZombieP"))
        {
            zombie.Actions.KBConter = zombie.Actions.KBTotalTime;
            if (collision.transform.position.x > transform.position.x)
            {
                player.Actions.KnockFromRight = false;
            }
            if (collision.transform.position.x <= transform.position.x)
            {
                player.Actions.KnockFromRight = true;
            }
        }
    }


    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "DamageP" && other.tag == "Player")
        {
            other.GetComponent<Player>().Actions.TakeHit();
        }
        if (colliderName == "DamageP" && other.tag == "Shadow")
        {
            other.GetComponent<Shadow>().Actions.TakeHit();
        }
        if (colliderName == "DamageP" && other.tag == "ZombieP")
        {
            other.GetComponent<Zombie>().Actions.TakeHit();
        }
    }
}