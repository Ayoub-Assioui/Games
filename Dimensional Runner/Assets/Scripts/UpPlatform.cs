using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPlatform : MonoBehaviour
{
 
    public Animator animator;
    public float speed = 2f;
    public Vector2 direction = Vector2.up;
    public float stopTime = 5f; // time to stop moving after player enters trigger
    private float timer = 0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the difference in position between the platform and the player
            Vector2 difference = other.transform.position - transform.position;

            // Check if the timer has not exceeded stopTime
            if (timer < stopTime)
            {
                // Move the platform in the direction of movement
                transform.Translate(direction * speed * Time.deltaTime);
                timer += Time.deltaTime;
            }

            // Move the player along with the platform
            other.transform.position = (Vector2)transform.position + difference;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.Play("Move");

            AudioManager.instance.Play("Platform");
        }
    }
}


