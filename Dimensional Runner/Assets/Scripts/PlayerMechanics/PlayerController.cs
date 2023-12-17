using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float jumpForceMin;
    public float jumpForceMax;
    public float jumpLengthMin;
    public float jumpLengthMax;
    public float maxHoldTime;
    private float jumpLength;
    private float startHoldTime;
    private float jumpForce;
    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatisGrounded;
    public Transform wallCheck;
    public float wallCheckDistance;
    public LayerMask whatIsWall;
    //public LayerMask whatisSliding;
    private bool jumpBuffered;
    private bool canJump = true;
    private bool isWallSliding;
    private bool isTouchingWall;
    //private bool isSliding;
    private int wallSide;
    private bool facingRight = true;

    public float dashForce;
    public bool isDashing = false;

    //public PhysicsMaterial2D slippery;


    


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisGrounded);
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckDistance, whatIsWall);
        //isSliding = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisSliding);

        if (isTouchingWall && !isGrounded)
        {
            isWallSliding = true;

        }
        else
        {
            isWallSliding = false;

        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isGrounded && canJump)
            {
                startHoldTime = Time.time;
                canJump = false;
            }
            else if (isWallSliding && !isGrounded)
            {
                JumpOffWall();
            }
            else if (!isGrounded && !isWallSliding)
            {
                jumpBuffered = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (isGrounded)
            {
                Jump();

            }
            else if (isWallSliding)
            {
                WallJump();
            }

            jumpBuffered = false;
        }

        if (isGrounded && jumpBuffered)
        {
            Jump();
            jumpBuffered = false;
        }

        if (Input.GetMouseButtonDown(0) && isDashing)
        {
            // Cancel out gravity while dashing
            rb.gravityScale = 0;
            // Get the direction the player is facing
            //Vector2 dashDirection = facingRight ? Vector2.right : Vector2.left;

            // Apply a force to the Rigidbody2D component in the direction the player is facing
            rb.velocity = new Vector2((facingRight ? 1 : -1) * dashForce, 0);



            AudioManager.instance.Play("Dash");

        }
        /* if(isSliding)
         {
             slippery.friction = 0f;
             animator.Play("sliding");

         }*/


        else
        {
            rb.gravityScale = 1.1f;
            //slippery.friction = 0.4f;
        }


    }

    private void Jump()
    {
        float holdTime = Time.time - startHoldTime;

        jumpLength = Mathf.Lerp(jumpLengthMin, jumpLengthMax, holdTime / maxHoldTime);
        jumpForce = Mathf.Lerp(jumpForceMin, jumpForceMax, holdTime / maxHoldTime);

        // Get the direction the player is facing
        Vector2 direction = facingRight ? Vector2.right : Vector2.left;

        // Apply the direction to the jump
        rb.velocity = new Vector2(jumpLength * direction.x, jumpForce);

        animator.Play("jump");

        AudioManager.instance.Play("Jump");

        canJump = false;
    }

    private void JumpOffWall()
    {
        // Calculate the jump velocity using the opposite direction of the wallSide and the player's direction
        float jumpDirection = facingRight ? -1 : 1;
        rb.velocity = new Vector2(jumpDirection * jumpLengthMax, jumpForceMax);

        // Flip the player's scale and direction
        Flip();
        AudioManager.instance.Play("Jump");
    }



    private void WallJump()
    {
        // Calculate the jump velocity using the new wallSide direction
        wallSide = facingRight ? -1 : 1;
        rb.velocity = new Vector2(wallSide * jumpLengthMax, jumpForceMax);

        // Flip the player's scale and direction
        Flip();

        animator.Play("jump");

       // AudioManager.instance.Play("Jump");

        canJump = false;
    }




    private void Flip()
    {
        // Switch the value of facingRight
        facingRight = !facingRight;

        // Flip the player's scale
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            canJump = true;
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            canJump = true;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            isTouchingWall = true;
            wallSide = facingRight ? 1 : -1;

        }
        /*if (collision.gameObject.layer == LayerMask.NameToLayer("edge"))
         {

            isSliding = true;

         }
      */
    }
    private IEnumerator EndDash(float duration)
    {
        yield return new WaitForSeconds(duration);
        isDashing = false;

        rb.velocity = new Vector2(2, 0);
        animator.Play("Fall");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("dashobject") && !isDashing)
        {
            isDashing = true;
            StartCoroutine(EndDash(0.5f));

        }


    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            isTouchingWall = false;
        }
    }


}