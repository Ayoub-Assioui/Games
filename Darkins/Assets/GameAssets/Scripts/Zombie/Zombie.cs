using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private ZombieActions actions;

    [SerializeField] private ZombieComp components;

    [SerializeField] private ZombieRef refrences;

    [SerializeField] private ZombieStats stats;

    private ZombieUtil utilities;


    // Get the player conf
    public ZombieComp Components { get => components; }
    public ZombieStats Stats { get => stats; }
    public ZombieActions Actions { get => actions; }
    public ZombieUtil Utilities { get => utilities; }
    public ZombieRef Refrences { get => refrences; }



    // Start is called before the first frame update
    private void Start()
    {
        actions = new ZombieActions(this);
        utilities = new ZombieUtil(this);

        stats.IsImmortal = false;

        AnyStateAnimation[] animations = new AnyStateAnimation[]
        {
           new AnyStateAnimation("Idle","Hurt"),
            new AnyStateAnimation("Walk","Hurt"),
            
            
          
            new AnyStateAnimation("Hurt","Die"),
            new AnyStateAnimation("Die"),
            

        };

        

        UIManager.Instance.AddZLife(stats.ZLives);

        components.Animator.AddAnimations(animations);

    }

    // Update is called once per frame
    private void Update()
    {
        if (Stats.Alive)
        {
            utilities.HandleInput();
            

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