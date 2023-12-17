using UnityEngine;
using System.Collections;
public class PlayerCollision : MonoBehaviour
{

    public float knockbackForce = 10f;
    public float knockbackDuration = 0.5f;


    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                Time.timeScale = 0;
                //UiManager.isGameOver = true;
                //AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }

            else
            {
                // Apply knockback effect
                Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
                StartCoroutine(DoKnockback(knockbackDirection));
                StartCoroutine(GetHurt());
            }
        }
        if (collision.transform.tag == "ResEnemy")
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                Time.timeScale = 0;
                //UiManager.isGameOver = true;
                //AudioManager.instance.Play("GameOver");

            }
            else
            {

                //transform.position = UiManager.lastCheckPointPos;
                StartCoroutine(GetHurt());
            }
        }

        if (collision.transform.tag == "Enemylvl")
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                Time.timeScale = 0;
                //UiManager.isGameOver = true;
                //AudioManager.instance.Play("GameOver");

            }
            else
            {

                //transform.position = UiManager.lastCheckPointPos;
                Time.timeScale = 0;
                //UiManager.isGameOver = true;
            }
        }

    }

    IEnumerator DoKnockback(Vector2 direction)
    {
        // Disable player control
        GetComponent<JoystickController>().enabled = false;

        // Apply knockback force
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        // Wait for knockback duration
        yield return new WaitForSeconds(knockbackDuration);

        // Re-enable player control
        GetComponent<JoystickController>().enabled = true;
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        //AudioManager.instance.Play("Hurt");
        yield return new WaitForSeconds(0.2f);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }


}