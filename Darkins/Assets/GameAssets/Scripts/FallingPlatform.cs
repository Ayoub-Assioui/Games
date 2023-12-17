using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    private float FallDelay = 1f;

    private float DestroyDelay = 2f;

    [SerializeField] private Rigidbody2D rb2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(FallDelay);
        rb2.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, DestroyDelay);
    }
}
