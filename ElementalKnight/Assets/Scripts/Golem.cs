using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    public Animator animator;

    private bool MovingRight;
    private Vector3 initialPosition;
    [SerializeField] float speed;
    [SerializeField] float agroRange;
    [SerializeField] float attackRange;
    [SerializeField] float agrospeed;
    [SerializeField] Transform player;

    // Start is called before the first frame update
    void Start()
    {
       initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ENEMY MOVEMENTS
        if (MovingRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1.5f, 1.5f);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1.5f, 1.5f);
        }

        // Distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange && distToPlayer > attackRange)
        {
            // Chase player
            Chase();
        }
       

        if (distToPlayer < attackRange)
        {
            // ATTACK THE PLAYER
             animator.Play("GolemAttack");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WSword"))
        {
            StartCoroutine(DieAfterDelay(0.5f));
        }

        if (collision.gameObject.CompareTag("Turn"))
        {
            MovingRight = !MovingRight;
        }
    }

    private void Chase()
    {
        Vector2 directionToPlayer = player.position - transform.position;
        directionToPlayer.Normalize();

        transform.position += (Vector3)(directionToPlayer * agrospeed * Time.deltaTime);

        if (directionToPlayer.x > 0)
        {
            transform.localScale = new Vector2(-1.5f, 1.5f);
        }
        else
        {
            transform.localScale = new Vector2(1.5f, 1.5f);
        }
    }


    

    private IEnumerator DieAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
