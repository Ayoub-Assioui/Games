using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SEvent : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        /*
        AudioManager.instance.Play("MainMenu");
        AudioManager.instance.Stop("SpaceLevel");
        AudioManager.instance.Stop("LavaLevel");
        AudioManager.instance.Stop("CrystalPeak");
        */

    }

    public void LoadLevels(int index)
    {
        // Reset the last checkpoint position to its default value
        UiManager.lastCheckPointPos = new Vector2(-3, -0.4f);
        SceneManager.LoadScene(index);
    }
    public void GoToMenus()
    {
        SceneManager.LoadScene("Menu");
    }
}
