using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowUtilities
{
    private Shadow shadow;


    private List<Command> commands = new List<Command>();
    public ShadowUtilities(Shadow shadow)
    {
        this.shadow = shadow;
        
        commands.Add(new PossessionCommand(shadow, KeyCode.LeftControl));
        




    }

    public void HandleInput()
    {
        shadow.Stats.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), shadow.Components.Rb.velocity.y);

        foreach (Command command in commands)
        {
            if (Input.GetKeyDown(command.Key))
            {
                command.GetKeyDown();
            }

            if (Input.GetKeyUp(command.Key))
            {
                command.GetKeyUp();
            }

            if (Input.GetKey(command.Key))
            {
                command.GetKey();
            }
        }


    // transform
        if (Input.GetKeyDown(KeyCode.H))
        {
            shadow.Components.Animator.TryPlayAnimation("Hide");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            shadow.Components.Animator.TryPlayAnimation("Appear");
        }

        

    }

  
}
