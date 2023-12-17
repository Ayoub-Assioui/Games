using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shinigami : MonoBehaviour
{


    public UIManager uimanager;



    [SerializeField] float speed;



    public bool MovingRight;

    public Transform HumanShadow; 

    [SerializeField] float agroRange;

    [SerializeField] float attackRange;

    [SerializeField] float agrospeed;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
      


    }



    // Update is called once per frame
    void Update()
    {


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
        float distToPlayer = Vector2.Distance(transform.position, HumanShadow.transform.position);

         //print("disToPlayer" + distToPlayer);

        if (distToPlayer < agroRange && distToPlayer > attackRange)
        {
            //chase player
            Chase();


        }
        if (distToPlayer < attackRange)
        {
            
            animator.Play("Attack-shinigami");

            uimanager.GameOver();
            Time.timeScale = 0;



        }

    }

    private void OnTriggerEnter2D(Collider2D trig)
    {


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




    private void Chase()
    {

        if (transform.position.x < HumanShadow.transform.position.x)
        {
            transform.Translate(2 * Time.deltaTime * agrospeed, 0, 0);

            transform.localScale = new Vector2(-0.15f, 0.15f);

            animator.Play("Chase-shinigami");


        }
        else if (transform.position.x > HumanShadow.transform.position.x)
        {
            transform.Translate(-2 * Time.deltaTime * agrospeed, 0, 0);
            transform.localScale = new Vector2(0.15f, 0.15f);
            animator.Play("Chase-shinigami");

        }
    }

    
        
    
}