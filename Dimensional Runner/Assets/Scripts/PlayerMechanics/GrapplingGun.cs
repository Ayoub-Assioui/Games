using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    Collider2D currentZone; // The current anchor zone the player is in

    DistanceJoint2D rope;

    public LineRenderer lineRenderer;

    void Start()
    {
        gameObject.AddComponent<LineRenderer>();
        gameObject.AddComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Shot rope on mouse position
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the player is in a zone
            if (currentZone != null)
            {
                rope = gameObject.AddComponent<DistanceJoint2D>();
                rope.connectedAnchor = currentZone.bounds.center;

                // Enable the line renderer
                lineRenderer.enabled = true;

                // Set the line renderer positions
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, currentZone.bounds.center);

                AudioManager.instance.Play("Hook");
            }
        }

        // Destroy rope
        else if (Input.GetMouseButtonUp(0))
        {
            DestroyImmediate(rope);
            // Disable the line renderer
            lineRenderer.enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (rope != null)
        {
            // Update the line renderer's positions with the player and anchor positions
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, rope.connectedAnchor);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("anchorzone"))
        {
            // Store the current anchor zone
            currentZone = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("anchorzone"))
        {
            // Reset the current anchor zone
            currentZone = null;
        }
    }
}
