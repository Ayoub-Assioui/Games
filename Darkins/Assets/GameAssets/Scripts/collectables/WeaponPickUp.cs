/*
 
// This script is Allowing the Player to Pick up WEAPONS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour, ICollectable
{
    [SerializeField] private WEAPON weapon;

    public WEAPON Weapon { get => weapon; set => weapon = value; }

    public void Collect()
    {
        FindObjectOfType<Player>().Actions.PickUpWeapon(weapon);
        Destroy(gameObject);
    }
}
*/