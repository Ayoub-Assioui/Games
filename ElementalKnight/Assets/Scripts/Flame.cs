using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flame : MonoBehaviour
{


    public Animator animator;

    private bool MovingRight;
    [SerializeField] float speed;
    [SerializeField] float agroRange;
    [SerializeField] float attackRange;
    [SerializeField] float agrospeed;
    [SerializeField] Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ENEMY MOVEMENTS
        if (MovingRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);

            transform.localScale = new Vector2(-0.8f, 0.8f);
        }

        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(0.8f, 0.8f);
        }




        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        // print("disToPlayer" + distToPlayer);

        if (distToPlayer < agroRange && distToPlayer > attackRange)
        {
            //chase player
            Chase();


        }
        if (distToPlayer < attackRange)
        {
            //ATTACK THE PLAYER
            //animator.Play("Attack-Z");
        }
    }

   
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WSword"))
        {
            animator.Play("FlameDie");

            StartCoroutine(DieAfterDelay(0.5f));
        }


        if (collision.gameObject.CompareTag("Turn"))
        {
            if (MovingRight)
            {
                MovingRight = false;
            }
            else
            {
                MovingRight = true;
            }
        }
    }

    //Chase METHOD + FOLLOW ANIMATION

    private void Chase()
    {

        
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.Normalize();

            transform.position += directionToPlayer * agrospeed * Time.deltaTime;

            if (directionToPlayer.x > 0)
            {
                transform.localScale = new Vector2(-0.8f, 0.8f);
            }
            else
            {
                transform.localScale = new Vector2(0.8f, 0.8f);
            }
        

    }

    private IEnumerator DieAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}

