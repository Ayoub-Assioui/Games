using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossBehaviour : MonoBehaviour
{

   
        [SerializeField] float speed;

        public bool MovingRight;

        [SerializeField] Transform playerp;

        [SerializeField] float agroRange;

        [SerializeField] float attackRange;

        
     

        [SerializeField] float agrospeed;

        public Animator animator;

        float timePassed = 0f;

        

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
                transform.localScale = new Vector2(-0.7f, 0.7f);
               
        }
            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(0.7f, 0.7f);
                
        }

            //distance to player
            float distToPlayer = Vector2.Distance(transform.position, playerp.position);

            if (distToPlayer < agroRange && distToPlayer > attackRange)
            {
                //chase player
                Chase();
            }
            if (distToPlayer < attackRange)
            {
                //ATTACK THE PLAYER
                animator.Play("attack");
                


        }

            timePassed += Time.deltaTime;
            if (timePassed > 4f)
            {
                animator.Play("attack_02");
               
                timePassed = 0f;
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
            if (transform.position.x < playerp.position.x)
            {
                transform.Translate(2 * Time.deltaTime * agrospeed, 0, 0);
                transform.localScale = new Vector2(-0.7f, 0.7f);
                
            }
            else if (transform.position.x > playerp.position.x)
            {
                transform.Translate(-2 * Time.deltaTime * agrospeed, 0, 0);
                transform.localScale = new Vector2(0.7f, 0.7f);
                
        }
        }
    }


