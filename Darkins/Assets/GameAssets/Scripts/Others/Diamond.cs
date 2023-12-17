using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour, ICollectable
    {
        public void Collect()
        {
            UIManager.Instance.AddDiamond();
            Destroy(gameObject);
        }


    }