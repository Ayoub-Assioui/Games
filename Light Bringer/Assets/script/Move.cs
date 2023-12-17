using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    public float speed = 5;

    private bool hasItem = false;
    public GameObject wings;
    public GameObject wingsui;

    public float jumpSpeed = 5;
    public float jumpSpeedDouble = 3;
    bool isGrounded;
    bool canDoubleJump;
    public float delayBeforeDoubleJump;
    bool onBox;

    public Animator animator;

    //dash
    private bool hasDash = false;
    public GameObject dash;
    public GameObject dashui;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 12f;
    private float dashingTime = 0.1f;
    private float dashingCooldown = 1f;

    //walljump
    private bool isTouchingWall;
    
    //Sdash
  /* private float superdashingPower = 6f;
    private bool canSDash = true;
    private bool hasSDash = false;
    public GameObject Sdash;
    public GameObject Sdashui; 
    private bool isSDashing;
    private float SdashingTime = 2f;
    private float SdashingCooldown = 1f;*/
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;

        // Retrieve the hasItem value from PlayerPrefs
        hasItem = PlayerPrefs.GetInt("hasItem", 0) == 1;

        hasDash = PlayerPrefs.GetInt("hasDash", 0) == 1;
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (isDashing)
        {
            return;
        }

       /* if (isSDashing)
        {
            return;
        }
        */


        MovePlayer();

        if (!isGrounded && !onBox && rb.velocity.y < 0 && !isTouchingWall)
        {
            animator.SetBool("fall", true);
            animator.SetBool("move", false);
        }
    }

    private void MovePlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
            transform.localScale = new Vector2(-3f, 3f); // flip the player object horizontally
            //animator.Play("move");
            if(isGrounded || onBox)
            { animator.SetBool("move", true);
                
            }

            


        }
        else if (moveRight)
        {
            horizontalMove = speed;
            transform.localScale = new Vector2(3f, 3f); // flip the player object horizontally
            //animator.Play("move");
            if (isGrounded || onBox)
            { animator.SetBool("move", true);
                
            }
           ;

        }
        else if (rb.velocity.y < 0 && isTouchingWall)
        {
            rb.velocity = new Vector2(rb.velocity.x, -3f);
           
        }

        else
        {
            horizontalMove = 0;
            animator.SetBool("move", false);

        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
            animator.SetBool("fall", true);
            animator.SetBool("move", false);
        }

        else if (other.gameObject.tag == "Wall")
        {
            isTouchingWall = false;
            animator.SetBool("wallsliding", false);
            //animator.SetBool("fall", false);

        }
        if (other.gameObject.tag == "Box")
        {
            onBox = false;
            
            
        }
       
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wings"))
        {
            // Add code here to disable the collectible item (e.g., set it to inactive) 
            CollectItem();
        }

        if (other.gameObject.CompareTag("Dash"))
        {
            // Add code here to disable the collectible item (e.g., set it to inactive) 
            CollectItemD();
        }

        if (other.gameObject.CompareTag("SDash"))
        {
            // Add code here to disable the collectible item (e.g., set it to inactive) 
           // CollectItemSD();
        }
        
    }


  

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            canDoubleJump = false;
            animator.SetBool("fall", false);
        }
        else if (other.gameObject.tag == "Wall")
        {
            isTouchingWall = true;
            animator.SetBool("wallsliding", true);
            animator.SetBool("fall", false);

            
        }
        if (other.gameObject.tag == "Box")
        {
            onBox = true;
            canDoubleJump = false;
            animator.SetBool("fall", false);


        }
       

    }
    public void jump()
    {
        if (isGrounded || onBox)
        {
            isGrounded = false;
            rb.velocity = Vector2.up * jumpSpeed;
            animator.Play("jump");
            //animator.SetBool("jump", true);
            AudioManager.instance.Play("Jump");
            Invoke("EnableDoubleJump", delayBeforeDoubleJump);
        }

        
         if (canDoubleJump && hasItem)
         {
             rb.velocity = Vector2.up * jumpSpeedDouble;
             canDoubleJump = false;
            animator.Play("doublejump");
            AudioManager.instance.Play("Wings");
        }
       
    }

  /*  public void SuperDash()
    {
       
        if (canSDash)
        {

            StartCoroutine(SDash());
        }
    }
     private IEnumerator SDash()
    {
        canSDash = false;
        isSDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * superdashingPower, 0f);
        animator.SetBool("superdash",true);
        yield return new WaitForSeconds(SdashingTime);
        
        rb.gravityScale = originalGravity;
        isSDashing = false;
        animator.SetBool("superdash", false);
        yield return new WaitForSeconds(SdashingCooldown);
        canSDash = true;
    } */

    public void Dash()
    {
        if (canDash && hasDash)
        {

            StartCoroutine(TDash());
        }
    }

    private IEnumerator TDash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        animator.Play("dash");
        AudioManager.instance.Play("Dash");
        yield return new WaitForSeconds(dashingTime);
        //tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

 

    void EnableDoubleJump()
     {
         canDoubleJump = true;
     }

    private void CollectItem()
    {
        hasItem = true;
        AudioManager.instance.Play("Collect");
        wings.SetActive(false);
        wingsui.SetActive(true);

        // Save the hasItem value using PlayerPrefs
        PlayerPrefs.SetInt("hasItem", hasItem ? 1 : 0);



        PlayerPrefs.Save();

        // Call the DisableObject function after another delay of 3 seconds
        Invoke("DisableObject", 3f);
    }
    private void CollectItemD()
    {
        hasDash = true;
        AudioManager.instance.Play("Collect");
        dash.SetActive(false);
        dashui.SetActive(true);

        // Save the hasItem value using PlayerPrefs
        PlayerPrefs.SetInt("hasDash", hasDash ? 1 : 0);



        PlayerPrefs.Save();

        // Call the DisableObject function after another delay of 3 seconds
        Invoke("DisableDash", 3f);
    }

   /* private void CollectItemSD()
    {
        hasSDash = true;
        Sdash.SetActive(false);
        Sdashui.SetActive(true);

        // Save the hasItem value using PlayerPrefs
        PlayerPrefs.SetInt("hasSDash", hasSDash ? 1 : 0);



        PlayerPrefs.Save();

        // Call the DisableObject function after another delay of 3 seconds
        Invoke("DisableSDash", 3f);
    }*/
    void DisableObject()
    {
        // Disable the game object
        wingsui.SetActive(false);

    }

    void DisableDash()
    {
        // Disable the game object
        dashui.SetActive(false);

    }

    void DisableSDash()
    {
        // Disable the game object
        //Sdashui.SetActive(false);

    }


    private void FixedUpdate()
    {

        if (isDashing)
        {
            return;
        }
        /*if (isSDashing)
        {
            return;
        }
        */
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        
        
    }
}
