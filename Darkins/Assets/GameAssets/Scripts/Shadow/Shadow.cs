using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{

   

    private ShadowActions actions;

    [SerializeField] private ShadowComponents components;

    [SerializeField] private ShadowRefrences refrences;

    [SerializeField] private ShadowStats stats;

    private ShadowUtilities utilities;


    // Get the player conf
    public ShadowComponents Components { get => components; }
    public ShadowStats Stats { get => stats; }
    public ShadowActions Actions { get => actions; }
    public ShadowUtilities Utilities { get => utilities; }
    public ShadowRefrences Refrences { get => refrences; }
 


    // Start is called before the first frame update
    private void Start()
    {
       
        actions = new ShadowActions(this);
        utilities = new ShadowUtilities(this);
        stats.Speed = stats.WalkSpeed;
        stats.IsImmortal = false;

        AnyStateAnimation[] animations = new AnyStateAnimation[]
        {
            new AnyStateAnimation("Idle","Attack","Hurt","Hide","Appear"),
            new AnyStateAnimation("Walk","Attack","Hurt","Hide","Appear"),  
            new AnyStateAnimation("Attack","Hurt"),
            new AnyStateAnimation("Hurt","Die"),
            new AnyStateAnimation("Die"),
            new AnyStateAnimation("Hide"),
            new AnyStateAnimation("Appear")



        };

        Components.Animator.AnimationTriggerEvent += actions.Shoot;
        

        UIManager.Instance.AddSLife(stats.SLives);

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
