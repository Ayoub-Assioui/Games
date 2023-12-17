using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShadowStats
{


    public Vector2 Direction { get; set; }

    public float Speed { get; set; }

    

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float runSpeed;


    [SerializeField]
    private int slives;

    [SerializeField]
    private float immortalityTime;


    public float WalkSpeed
    { get => walkSpeed; }
    
    public bool Alive
    {
        get
        {
            return SLives > 0;
        }
    }
    

    
    public int SLives { get => slives; set => slives = value; }

    public bool IsImmortal { get; set; }
    public float ImmortalityTime { get => immortalityTime; set => immortalityTime = value; }
}
