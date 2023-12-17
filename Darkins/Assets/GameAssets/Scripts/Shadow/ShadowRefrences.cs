using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShadowRefrences
{
    public UIManager gameover;

    [SerializeField] GameObject projectilePrefab;

    [SerializeField] private Transform attackSpawn;
    
    public Transform AttackSpawn { get => attackSpawn; private set => attackSpawn = value; }
    public GameObject ProjectilePrefab { get => projectilePrefab; set => projectilePrefab = value; }
}

