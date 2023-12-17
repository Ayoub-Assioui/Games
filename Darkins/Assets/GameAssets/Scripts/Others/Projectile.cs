using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 direction;

    [SerializeField] private string targetTag;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void Setup(Vector2 direction)
    {
        // Get the scale of the projectile
        float scale = transform.localScale.x;

        // Set the scale of the projectile
        transform.localScale = new Vector3(scale * direction.x, scale, scale);

        // Set the direction of the projectile
        this.direction = direction;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == targetTag)
        {
            collision.GetComponentInParent<IHitable>().TakeHit();
            Destroy(gameObject);
        }
    }
}
