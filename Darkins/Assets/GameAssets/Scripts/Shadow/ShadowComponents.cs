using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShadowComponents
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private AnyStateAnimator animator;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private SpriteRenderer[] spriteRenderers;

    [SerializeField] private Collider2D collider;

    public Rigidbody2D Rb { get => rb; }
    public AnyStateAnimator Animator { get => animator; }
    public LayerMask GroundLayer { get => groundLayer; }
    public Collider2D Collider { get => collider; }
    public SpriteRenderer[] SpriteRenderers { get => spriteRenderers; set => spriteRenderers = value; }
}
