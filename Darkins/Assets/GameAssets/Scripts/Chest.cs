using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour,ICollectable
{
    public Animator animator;

    public GameObject itemDrops;

    bool itemInstantiated = false;


    public void Collect()
    {
        animator.Play("Open");

        ItemDrop();

    }

    public void ItemDrop()
    {
        if (!itemInstantiated)
        {
            Instantiate(itemDrops, transform.position, Quaternion.identity);
            itemInstantiated = true;
        }
    }



}

