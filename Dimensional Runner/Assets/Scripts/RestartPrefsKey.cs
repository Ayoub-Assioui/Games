using UnityEngine;

public class RestartPrefsKey : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartPrefs();
        }
    }

    public void RestartPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Player preferences reset.");
    }
}
