using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollisionTemp 
{
    void CollisionEnter(string colliderName, GameObject other);
    void CollisionExit(string name, GameObject gameObject);
}
