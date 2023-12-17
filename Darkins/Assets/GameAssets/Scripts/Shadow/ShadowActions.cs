using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowActions
{

    


    public float KBForce = 10f;


    public float KBConter = 0f;


    public float KBTotalTime = 1f;


    private bool moveLeft;
    private bool moveRight;

    public bool KnockFromRight { get; set; }



    private Shadow shadow;


    public ShadowActions(Shadow shadow)
    {
        this.shadow = shadow;
    }



    public void Move( Transform transform)
    {
        if (KBConter <= 0)
        {
            shadow.Components.Rb.velocity = new Vector2(shadow.Stats.Direction.x * shadow.Stats.Speed * Time.deltaTime, shadow.Components.Rb.velocity.y);

            if (shadow.Stats.Direction.x != 0)
            {
               transform.localScale = new Vector3(shadow.Stats.Direction.x < 0 ? -0.4f : 0.4f, 0.4f, 0.4f);
                shadow.Components.Animator.TryPlayAnimation("Walk");
            }
            else if (shadow.Components.Rb.velocity == Vector2.zero)
            {
                shadow.Components.Animator.TryPlayAnimation("Idle");
            }
        }

        else
        {
            if (KnockFromRight == true)
            {
                shadow.Components.Rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                shadow.Components.Rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBConter -= Time.deltaTime;
        }

    }





    public void Attack()
    {
        shadow.Components.Animator.TryPlayAnimation("Attack");
    }
    //shoot the special attack
    public void Shoot(string animation)
    {
        if (animation == "shoot")
        {
            GameObject proj = GameObject.Instantiate(shadow.Refrences.ProjectilePrefab, shadow.Refrences.AttackSpawn.position, Quaternion.identity);

            Vector3 direction = new Vector3(shadow.transform.lossyScale.x, 0);



            proj.GetComponent<Projectile>().Setup(direction);

        }
    }


   



// get damaged
public void TakeHit()
    {

        if (!shadow.Stats.IsImmortal)
        {
            if (shadow.Stats.SLives > 0)
            {

                UIManager.Instance.RemoveSLife();
                shadow.Stats.SLives--;
                shadow.Components.Animator.TryPlayAnimation("Hurt");
            }
            if (shadow.Stats.Alive)
            {
                shadow.StartCoroutine(Immortality());
            }
            if (!shadow.Stats.Alive)
            {
                Die();
            }
        }
    }
    // the sprites blinking time
    private IEnumerator Blink()
    {
        while (shadow.Stats.IsImmortal)
        {
            for (int i = 0; i < shadow.Components.SpriteRenderers.Length; i++)
            {
                shadow.Components.SpriteRenderers[i].enabled = false;
            }
            yield return new WaitForSeconds(.1f);

            for (int i = 0; i < shadow.Components.SpriteRenderers.Length; i++)
            {
                shadow.Components.SpriteRenderers[i].enabled = true;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
    // immortality time when hit 
    private IEnumerator Immortality()
    {
        shadow.Stats.IsImmortal = true;
        shadow.StartCoroutine(Blink());
        yield return new WaitForSeconds(shadow.Stats.ImmortalityTime);
        shadow.Stats.IsImmortal = false;
    }


    public void Collide(Collider2D collision)
    {
        if (collision.tag == "Collectables")
        {
            collision.GetComponent<ICollectable>().Collect();
        }
    }
    public void Die()
    {
        shadow.Refrences.gameover.GameOver();
        shadow.Components.Animator.TryPlayAnimation("Die");
        Time.timeScale = 0;
    }

  

}
