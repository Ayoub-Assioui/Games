using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions 
{
    private Player player;

    
    public float KBForce = 10f;

    
    public float KBConter = 0f;

    
    public float KBTotalTime = 1f;

    

    public bool KnockFromRight { get;  set; }

    public PlayerActions(Player player) 
    {
        this.player = player;
    }
    public void Move(Transform transform)
    {
        if(KBConter<=0)
        {
            if (Input.GetKey(KeyCode.V) && player.Utilities.isGrounded())
            {
                player.Components.Rb.velocity = new Vector2(player.Stats.Direction.x * player.Stats.RunSpeed * Time.deltaTime, player.Components.Rb.velocity.y);

                if (player.Stats.Direction.x != 0)
                {

                    transform.localScale = new Vector3(player.Stats.Direction.x < 0 ? -0.2345077f : 0.2345077f, 0.215768f, 1);
                    player.Components.Animator.TryPlayAnimation("Run");
                }
            }

            else
            {
                player.Components.Rb.velocity = new Vector2(player.Stats.Direction.x * player.Stats.WalkSpeed * Time.deltaTime, player.Components.Rb.velocity.y);

                if (player.Stats.Direction.x != 0)
                {

                    transform.localScale = new Vector3(player.Stats.Direction.x < 0 ? -0.2345077f : 0.2345077f, 0.215768f, 1);
                    player.Components.Animator.TryPlayAnimation("Walk");
                }
                else if (player.Components.Rb.velocity == Vector2.zero)
                {
                    player.Components.Animator.TryPlayAnimation("Idle");
                }
            }
           
        }

        else
        {
            if (KnockFromRight == true)
            {
                player.Components.Rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                player.Components.Rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBConter -= Time.deltaTime;
        }


       

    }


    /*
    // PICK UP WEAPONS METHOD

    internal void PickUpWeapon(WEAPON weapon)
    {
        player.Stats.Weapons[weapon] = true;
    }
    */

    public void Jump()
    {

        if(player.Utilities.isGrounded())
        {
            player.Components.Rb.AddForce(new Vector2(0, player.Stats.JumpForce), ForceMode2D.Impulse);
            player.Components.Animator.TryPlayAnimation("Jump");
        }
        
    }

    public void Attack()
    {

        player.Components.Animator.TryPlayAnimation("Attack");

    }

    /*
     
    //SWITCHING BETWEEN PICKED WEAPONS
      public void TrySwapWeapon(WEAPON weapon)
    {
        if (player.Stats.Weapons[weapon] == true)
        {
            player.Stats.Weapon = weapon;
            player.Components.Animator.SetWeapon((int)player.Stats.Weapon);
            SwapWeapon();
        }
        
    }

    public void SwapWeapon()
    {
        for(int i = 1 ; i < player.Refrences.WeaponObjects.Length ; i++)
        {
            player.Refrences.WeaponObjects[i].SetActive(false);
        }

        if (player.Stats.Weapon > 0)
        {
            player.Refrences.WeaponObjects[(int)player.Stats.Weapon].SetActive(true);
        }
    }
    */

    public void TakeHit()
    {

        if(!player.Stats.IsImmortal)
        {
            if (player.Stats.Lives > 0)
            {
                
                UIManager.Instance.RemoveLife();
                player.Stats.Lives--;
                player.Components.Animator.TryPlayAnimation("Hurt");
            }
            if (player.Stats.Alive)
            {
                player.StartCoroutine(Immortality());
            }
            if (!player.Stats.Alive)
            {
                Die();
            }
        }
    }
    // sprites blinking time
    private IEnumerator Blink()
    {
        while (player.Stats.IsImmortal)
        {
            for (int i = 0; i < player.Components.SpriteRenderers.Length ; i++)
            {
                player.Components.SpriteRenderers[i].enabled = false;
            }
            yield return new WaitForSeconds(.1f);

            for (int i = 0; i < player.Components.SpriteRenderers.Length; i++)
            {
                player.Components.SpriteRenderers[i].enabled = true;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
    // immortality time when hit
    private IEnumerator Immortality()
    {
        player.Stats.IsImmortal = true;
        player.StartCoroutine(Blink());
        yield return new WaitForSeconds(player.Stats.ImmortalityTime);
        player.Stats.IsImmortal = false;
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
        player.Refrences.gameover.GameOver();
        player.Components.Animator.TryPlayAnimation("Die");
        Time.timeScale = 0;
    }

   

    
}
