using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private PlayerActions actions;

    [SerializeField] private PlayerComponents components;

    [SerializeField] private PlayerRefrences refrences;

    [SerializeField]private PlayerStats stats;

    private PlayerUtilities utilities;


    // Get the player conf
    public PlayerComponents Components {get => components;}
    public PlayerStats Stats { get => stats; }
    public PlayerActions Actions { get => actions;}
    public PlayerUtilities Utilities { get => utilities;}
    public PlayerRefrences Refrences { get => refrences;}



    // Start is called before the first frame update
    private void Start()
    {
        actions = new PlayerActions(this);
        utilities = new PlayerUtilities(this);
        
        stats.IsImmortal = false;

        AnyStateAnimation[] animations = new AnyStateAnimation[]
        {
            new AnyStateAnimation("Idle","Attack","Hurt"),
            new AnyStateAnimation("Walk","Run","Jump","Fall","Attack","Hurt"),
            new AnyStateAnimation("Jump","Hurt"),
            new AnyStateAnimation("Fall","Hurt"),
            new AnyStateAnimation("Attack","Hurt"),
            new AnyStateAnimation("Hurt","Die"),
            new AnyStateAnimation("Die"),
             new AnyStateAnimation("Run","Jump","Fall","Attack","Hurt")


        };

        //stats.Weapons.Add(WEAPON.FISTS, true);
        //stats.Weapons.Add(WEAPON.Sword, false);

        Refrences.SwordDamage.gameObject.SetActive(false);

        UIManager.Instance.AddLife(stats.Lives);

        components.Animator.AddAnimations(animations);

    }

    // Update is called once per frame
    private void Update()
    {
        if (Stats.Alive)
        {
            utilities.HandleInput();
            utilities.HandleAir();
            
        }
        
        
            
        


    }

private void FixedUpdate()
    {
        if (Stats.Alive)
        {
            actions.Move(transform);
            
        }

      
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        actions.Collide(collision);
    }
}
