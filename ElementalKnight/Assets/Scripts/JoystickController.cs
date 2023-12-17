using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public FixedJoystick joystick;
    public Rigidbody2D rb;
    public float moveSpeed;
    public Animator animator;

    private bool isDashing = false;
    public float dashDuration = 0.3f;
    public float dashSpeed = 10f;
    public float dashTimer = 0f;

    private Vector2 move;

    void Update()
    {
        if (!isDashing)
        {
            move.x = joystick.Horizontal;
            move.y = joystick.Vertical;

            // check the direction of movement
            if (move.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1); // facing right
                animator.SetBool("walk", true);
            }
            else if (move.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); // facing left
                animator.SetBool("walk", true);
            }
            else
            {
                animator.SetBool("walk", false);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + move.normalized * dashSpeed * Time.fixedDeltaTime);
            dashTimer -= Time.fixedDeltaTime;
            if (dashTimer <= 0f)
            {
                isDashing = false;
                animator.SetBool("dash", false);
            }
        }
    }

    public void Dash()
    {
        if (!isDashing && move.magnitude > 0f)
        {
            isDashing = true;
            dashTimer = dashDuration;
            animator.SetBool("dash", true);
        }
    }

    public void Attack()
    {
        // Your attack code here
    }
}
