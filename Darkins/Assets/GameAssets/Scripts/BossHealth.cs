using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour,IHitable
{

    // Flag to indicate if the enemy has been hit by the projectile
    private bool isHit = false;

    public Slider healthBar;

    public float maxHealth;

    public float currentHealth;

    public float damage;

    public float damageS;

    public Animator animator;

    public GameObject bar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.value = CalculateHealth();
    }

    void Update()
    {
        healthBar.value = CalculateHealth();

        if (currentHealth < 0)
        {
            BossDie();
            bar.SetActive(false);
        }
    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

  

    public void TakeHit()
    {
        isHit = true;
        currentHealth -= damage;
        animator.Play("demage");
        
    }
    public bool IsHit()
    {
        // Return whether the enemy has been hit by the projectile
        return isHit;
    }

    // Hit by a Sword
    public void TakeHitS()
    {
        // Set isHit to true to indicate that the enemy has been hit by the projectile
        isHit = true;
        currentHealth -= damageS;
        animator.Play("demage");
    }

    public void BossDie()
    {
        animator.SetTrigger("Die");
        GetComponent<BossBehaviour>().enabled = false;
    }
}
