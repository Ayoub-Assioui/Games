using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS IS FOR THE ENTRING AND EXITING THE COLIISION
public class CollisionTriggerTemp : MonoBehaviour
{
    private ICollisionHandler handler;

    private ICollisionTemp temp;

    private void Start()
    {
        handler = GetComponentInParent<ICollisionHandler>();
        temp = GetComponentInParent<ICollisionTemp>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        handler.CollisionEnter(gameObject.name, collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        temp.CollisionExit(gameObject.name, collision.gameObject);
    }
}
