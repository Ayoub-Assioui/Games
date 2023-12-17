using UnityEngine;



public class CheckPoint : MonoBehaviour
{

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {

           
            UiManager.lastCheckPointPos = transform.position;
            AudioManager.instance.Play("Checkpoint");
            //GetComponent<SpriteRenderer>().color = Color.green;
            //AudioManager.instance.Play("Checkpoint");
        }
    }
   
}