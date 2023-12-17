/*

ALLOWS THE ZOMBIE TO ATTACK

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ZAttackCommand : Command
{
    private Zombie zombie;



    public ZAttackCommand(Zombie zombie, KeyCode key) : base(key)
    {
        this.zombie = zombie;

    }

    public override void GetKeyDown()
    {
        zombie.Actions.Attack();
    }

}


*/