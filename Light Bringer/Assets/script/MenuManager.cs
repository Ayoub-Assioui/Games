using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    



  

   
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToLevels()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Selection");
    }

    /*public void GameOver()
    {
        Time.timeScale = 0;

        GameOverscreen.SetActive(true);
    }

    */
}
