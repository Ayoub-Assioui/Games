using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieActions 
{
    private Zombie zombie;

    public float KBForce = 10f;


    public float KBConter = 0f;


    public float KBTotalTime = 1f;



    public bool KnockFromRight { get; set; }

    public ZombieActions(Zombie zombie)
    {
        this.zombie = zombie;
    }
    public void Move(Transform transform)
    {
        if (KBConter <= 0)
        {

            zombie.Components.Rb.velocity = new Vector2(zombie.Stats.Direction.x * zombie.Stats.WalkSpeed * Time.deltaTime, zombie.Components.Rb.velocity.y);

            if (zombie.Stats.Direction.x != 0)
            {

                transform.localScale = new Vector3(zombie.Stats.Direction.x < 0 ? 0.15f : -0.15f, 0.15f, 1);
                zombie.Components.Animator.TryPlayAnimation("Walk");
            }
            else if (zombie.Components.Rb.velocity == Vector2.zero)
            {
                zombie.Components.Animator.TryPlayAnimation("Idle");
            }

        }

        else
        {
            if (KnockFromRight == true)
            {
                zombie.Components.Rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                zombie.Components.Rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBConter -= Time.deltaTime;
        }
    }


    /*
      
     
    public void Attack()
    {

        zombie.Components.Animator.TryPlayAnimation("Attack");

    }

   */


    public void TakeHit()
    {

        if (!zombie.Stats.IsImmortal)
        {
            if (zombie.Stats.ZLives > 0)
            {
                UIManager.Instance.RemoveZLife();
                zombie.Stats.ZLives--;
                zombie.Components.Animator.TryPlayAnimation("Hurt");
            }
            if (zombie.Stats.Alive)
            {
                zombie.StartCoroutine(Immortality());
            }
            if (!zombie.Stats.Alive)
            {
                Die();
            }
        }
    }

    private IEnumerator Blink()
    {
        while (zombie.Stats.IsImmortal)
        {
            for (int i = 0; i < zombie.Components.SpriteRenderers.Length; i++)
            {
                zombie.Components.SpriteRenderers[i].enabled = false;
            }
            yield return new WaitForSeconds(.1f);

            for (int i = 0; i < zombie.Components.SpriteRenderers.Length; i++)
            {
                zombie.Components.SpriteRenderers[i].enabled = true;
            }
            yield return new WaitForSeconds(.1f);
        }
    }

    private IEnumerator Immortality()
    {
        zombie.Stats.IsImmortal = true;
        zombie.StartCoroutine(Blink());
        yield return new WaitForSeconds(zombie.Stats.ImmortalityTime);
        zombie.Stats.IsImmortal = false;
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
        zombie.Refrences.gameover.GameOver();
        zombie.Components.Animator.TryPlayAnimation("Die");
        Time.timeScale = 0;
    }

}
