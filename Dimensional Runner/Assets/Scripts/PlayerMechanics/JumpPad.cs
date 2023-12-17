using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{

    //public UiManager uiManager;

    public float bounce;

    //public Rigidbody2D rb;

    public ParticleSystem puuf; // Reference to the particle system to spawn.


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the Rigidbody component of the collided object.
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            rb.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);

            AudioManager.instance.Play("Bounce");

            // Spawn the particle system at the point of collision.
            ParticleSystem ps = Instantiate(puuf, collision.GetContact(0).point, Quaternion.identity);

            // Play the particle system.
            ps.Play();
        }
    }


}
