using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghostbehaviour : MonoBehaviour
{
    [SerializeField] float speed;



    public bool MovingRight;

    [SerializeField] Transform player;

    [SerializeField] float agroRange;

    [SerializeField] float attackRange;

    [SerializeField] float agrospeed;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {

        // ENEMY MOVEMENTS
        if (MovingRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);

            transform.localScale = new Vector2(-0.15f, 0.15f);
        }

        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(0.15f, 0.15f);
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
            animator.Play("attack-ghost");
        }

    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        //Turn when hitting the Turngameobject

        if (trig.gameObject.CompareTag("Turn"))
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

        if (transform.position.x < player.position.x)
        {
            transform.Translate(2 * Time.deltaTime * agrospeed, 0, 0);

            transform.localScale = new Vector2(-0.15f, 0.15f);

            animator.Play("chase-ghost");


        }
        else if (transform.position.x > player.position.x)
        {
            transform.Translate(-2 * Time.deltaTime * agrospeed, 0, 0);
            transform.localScale = new Vector2(0.15f, 0.15f);
            animator.Play("chase-ghost");
        }
    }


}
