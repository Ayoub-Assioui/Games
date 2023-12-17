using UnityEngine;
using System.Collections;
public class PlayerCollision : MonoBehaviour
{



    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                Time.timeScale = 0;
                UiManager.isGameOver = true;
                //AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }

            else
            {
                StartCoroutine(GetHurt());
            }
        }
        if (collision.transform.tag == "ResEnemy")
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                Time.timeScale = 0;
                UiManager.isGameOver = true;
                //AudioManager.instance.Play("GameOver");

            }
            else
            {

                transform.position = UiManager.lastCheckPointPos;
                StartCoroutine(GetHurt());
            }
        }

        if (collision.transform.tag == "Enemylvl")
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                Time.timeScale = 0;
                UiManager.isGameOver = true;
                //AudioManager.instance.Play("GameOver");

            }
            else
            {

                transform.position = UiManager.lastCheckPointPos;
                Time.timeScale = 0;
                UiManager.isGameOver = true;
            }
        }

    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        AudioManager.instance.Play("Hurt");
        yield return new WaitForSeconds(0.2f);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }


}