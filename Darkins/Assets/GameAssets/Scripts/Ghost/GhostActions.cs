using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostActions 
{
    private Ghost ghost;



    public GhostActions(Ghost ghost)
    {
        this.ghost = ghost;
    }
    public void Move(Transform transform)
    {


        ghost.Components.Rb.velocity = new Vector2(ghost.Stats.Direction.x * ghost.Stats.WalkSpeed * Time.deltaTime, ghost.Components.Rb.velocity.y);

        if (ghost.Stats.Direction.x != 0)
        {

            transform.localScale = new Vector3(ghost.Stats.Direction.x < 0 ? 0.16f : -0.16f, 0.16f, 1);
            ghost.Components.Animator.TryPlayAnimation("Walk");
        }
        else if (ghost.Components.Rb.velocity == Vector2.zero)
        {
            ghost.Components.Animator.TryPlayAnimation("Idle");
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

        if (!ghost.Stats.IsImmortal)
        {
            if (ghost.Stats.GLives > 0)
            {
                UIManager.Instance.RemoveZLife();
                ghost.Stats.GLives--;
                ghost.Components.Animator.TryPlayAnimation("Hurt");
            }
            if (ghost.Stats.Alive)
            {
                ghost.StartCoroutine(Immortality());
            }
            if (!ghost.Stats.Alive)
            {
                Die();
            }
        }
    }

    private IEnumerator Blink()
    {
        while (ghost.Stats.IsImmortal)
        {
            for (int i = 0; i < ghost.Components.SpriteRenderers.Length; i++)
            {
                ghost.Components.SpriteRenderers[i].enabled = false;
            }
            yield return new WaitForSeconds(.1f);

            for (int i = 0; i < ghost.Components.SpriteRenderers.Length; i++)
            {
                ghost.Components.SpriteRenderers[i].enabled = true;
            }
            yield return new WaitForSeconds(.1f);
        }
    }

    private IEnumerator Immortality()
    {
        ghost.Stats.IsImmortal = true;
        ghost.StartCoroutine(Blink());
        yield return new WaitForSeconds(ghost.Stats.ImmortalityTime);
        ghost.Stats.IsImmortal = false;
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
        ghost.Refrences.gameover.GameOver();
        ghost.Components.Animator.TryPlayAnimation("Die");
        Time.timeScale = 0;
    }

}
