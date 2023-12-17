using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private GhostActions actions;

    [SerializeField] private GhostComp components;

    [SerializeField] private GhostRef refrences;

    [SerializeField] private GhostStats stats;

    private GhostUtil utilities;


    // Get the player conf
    public GhostComp Components { get => components; }
    public GhostStats Stats { get => stats; }
    public GhostActions Actions { get => actions; }
    public GhostUtil Utilities { get => utilities; }
    public GhostRef Refrences { get => refrences; }



    // Start is called before the first frame update
    private void Start()
    {
        actions = new GhostActions(this);
        utilities = new GhostUtil(this);

        stats.IsImmortal = false;

        AnyStateAnimation[] animations = new AnyStateAnimation[]
        {
           new AnyStateAnimation("Idle","Hurt"),
            new AnyStateAnimation("Walk","Hurt"),



            new AnyStateAnimation("Hurt","Die"),
            new AnyStateAnimation("Die"),


        };



        UIManager.Instance.AddGLife(stats.GLives);

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