using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostUtil 
{
    private Ghost ghost;


    private List<Command> commands = new List<Command>();
    public GhostUtil(Ghost ghost)
    {
        this.ghost = ghost;

        //commands.Add(new ZAttackCommand(zombie, KeyCode.LeftControl));




    }

    public void HandleInput()
    {
        ghost.Stats.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), ghost.Components.Rb.velocity.y);

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




    }

    public bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(ghost.Components.Collider.bounds.center, ghost.Components.Collider.bounds.size, 0, Vector2.down, 0.1f, ghost.Components.GroundLayer);

        return hit.collider != null;
    }



}
