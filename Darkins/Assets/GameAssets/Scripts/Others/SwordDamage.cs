using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] private string targetTag;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            collision.GetComponentInParent<IHitable>().TakeHitS();
           
        }
    }
}
