using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiplineBehavior : MonoBehaviour
{
    private float ziplineSpeed = 25;
    private bool isOnZipline = false;
    public Rigidbody2D rb;
    private LineRenderer zipline;


    private void Start()
    {
        // Find the GameObject in the scene that has the "Zipline" tag and contains a LineRenderer component
        GameObject ziplineObject = GameObject.FindWithTag("Zipline");
        if (ziplineObject != null)
        {
            zipline = ziplineObject.GetComponent<LineRenderer>();
        }
    }
    void Update()
    {
        if (isOnZipline && Input.GetMouseButton(0))
        {
            // Get the last point of the line renderer
            int lastPointIndex = zipline.positionCount - 1;
            Vector2 endPoint = zipline.GetPosition(lastPointIndex);

            // Calculate the direction vector from the player's position to the end point of the zipline
            Vector2 direction = (endPoint - (Vector2)transform.position).normalized;

            // Move the player along the zipline
            rb.velocity = direction * ziplineSpeed;

            //AudioManager.instance.Play("ZipLine");
        }
        else
        {
            rb.gravityScale = 1.1f;
           
        }

   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zipline"))
        {
            isOnZipline = true;
            AudioManager.instance.Play("ZipLine");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Zipline"))
        {
            isOnZipline = false;
            rb.velocity = Vector2.zero;
            AudioManager.instance.Stop("ZipLine");
        }
    }
}
