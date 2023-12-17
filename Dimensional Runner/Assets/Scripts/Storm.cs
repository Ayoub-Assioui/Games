using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : MonoBehaviour
{

    public float stormSpeed = 5f;
    public Vector3 stormDirection = new Vector3(1f, 0f, 0f);

    

    void Update()
    {
        // Move the storm in the specified direction
        transform.position += stormDirection * stormSpeed * Time.deltaTime;
    }

}
