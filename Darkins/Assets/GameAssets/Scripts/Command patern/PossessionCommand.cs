using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PossessionCommand : Command
{
    private Shadow shadow;

    

    public PossessionCommand(Shadow shadow, KeyCode key) : base(key)
    {
        this.shadow = shadow;
        
    }

    public override void GetKeyDown()
    {
        shadow.Actions.Attack();
    }

}
