using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    
    
    public GameObject tp;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the Rigidbody component of the collided object.
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            collision.gameObject.transform.position = tp.transform.position;

            rb.velocity = new Vector2(1, 0);

            AudioManager.instance.Play("TP");

        }
    }
}