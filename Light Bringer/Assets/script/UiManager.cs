using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    public GameObject GameOverscreen;
    public GameObject levelComplete;
    public GameObject pauseMenuScreen;


    public static bool isGameOver;







    public static Vector2 lastCheckPointPos = new Vector2(-3, -0.4f);



    private void Awake()
    {

        isGameOver = false;

        if (lastCheckPointPos != null)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
        }
    }

    void Update()
    {
        
        if (isGameOver)
        {
            GameOverscreen.SetActive(true);
        }
    }

    public void CompleteLevel()
    {
       
        
       
        Time.timeScale = 0;
        levelComplete.SetActive(true);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
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
