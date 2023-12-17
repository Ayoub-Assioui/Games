using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GhostStats
{
    public Vector2 Direction { get; set; }

    public float Speed { get; set; }



    [SerializeField]
    private float walkSpeed;




    [SerializeField]
    private int glives;

    [SerializeField]
    private float immortalityTime;



    public float WalkSpeed
    { get => walkSpeed; }


    public bool Alive
    {
        get
        {
            return GLives > 0;
        }
    }



    public int GLives { get => glives; set => glives = value; }

    public bool IsImmortal { get; set; }
    public float ImmortalityTime { get => immortalityTime; set => immortalityTime = value; }

}
