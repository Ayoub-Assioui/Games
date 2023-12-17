/*
 


 //THIS COMMAND ALLOWS THE PLAYER TO SWAPWEAPONS
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WEAPON { FISTS = 0, Sword}
public class WeaponSwapCommand : Command
{
    private Player player;

    private WEAPON weapon;

    public WeaponSwapCommand(Player player, WEAPON weapon, KeyCode key) : base(key)
    {
        this.weapon = weapon;
        this.player = player;
    }

    public override void GetKeyDown()
    {
        player.Actions.TrySwapWeapon(weapon);
    }

}



*/


