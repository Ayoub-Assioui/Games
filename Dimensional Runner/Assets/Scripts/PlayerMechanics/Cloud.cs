using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float bounce;

    

    //public ParticleSystem puuf; // Reference to the particle system to spawn.

    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the Rigidbody component of the collided object.
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 bounceDirection = Vector2.up + (Vector2.right * 0.5f); // Combine upward and forward directions
            rb.AddForce(bounceDirection.normalized * bounce, ForceMode2D.Impulse); // Apply the force

            animator.Play("CloudCollision");


            AudioManager.instance.Play("Cloud");

            // Spawn the particle system at the point of collision.
            //ParticleSystem ps = Instantiate(puuf, collision.GetContact(0).point, Quaternion.identity);

            // Play the particle system.
            //ps.Play();
        }
    }
}
