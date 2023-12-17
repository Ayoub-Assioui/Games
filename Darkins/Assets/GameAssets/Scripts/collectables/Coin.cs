using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour,ICollectable
{
    public void Collect()
    {
        UIManager.Instance.AddCoin();
        Destroy(gameObject);
    }

    
}
