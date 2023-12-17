using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerRefrences
{
    public UIManager gameover;

    public GameObject SwordDamage;

    [SerializeField]private GameObject[] weaponObjects;

    
    public GameObject[] WeaponObjects { get => weaponObjects; set => weaponObjects = value; }
   
}
    
