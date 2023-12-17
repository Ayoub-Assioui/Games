using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ZombieStats
{
    public Vector2 Direction { get; set; }

    public float Speed { get; set; }

    

    [SerializeField]
    private float walkSpeed;

    


    [SerializeField]
    private int zlives;

    [SerializeField]
    private float immortalityTime;

   

    public float WalkSpeed
    { get => walkSpeed; }
    

    public bool Alive
    {
        get
        {
            return ZLives > 0;
        }
    }
   

    
    public int ZLives { get => zlives; set => zlives = value; }

    public bool IsImmortal { get; set; }
    public float ImmortalityTime { get => immortalityTime; set => immortalityTime = value; }
    
}
