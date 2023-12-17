using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCheckpoint : MonoBehaviour
{
    public GameObject reward;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            reward.SetActive(true);
         
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        reward.SetActive(false);
    }
}
