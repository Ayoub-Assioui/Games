
using UnityEngine;

public class DisableBackgroundOnCollision : MonoBehaviour,ICollectable
{
    public GameObject background; // Drag the background game object here in the inspector
    
    public void Collect()
    {
       
            background.SetActive(false);
        

    }
}