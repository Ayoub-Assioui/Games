using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class UiManager : MonoBehaviour
{
    public GameObject GameOverscreen;
    public GameObject levelComplete;
    public GameObject pauseMenuScreen;
    public GameObject CoinsAdded;

    public static int numberOfCoins;
    public Text coinsText;
    int addCoin = 20;
    


    public CinemachineVirtualCamera VCam;
    public GameObject[] playerPrefabs;
    int characterIndex;

    public static Vector2 lastCheckPointPos = new Vector2(2, -2);

    

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        VCam.m_Follow = player.transform;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", numberOfCoins);
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = numberOfCoins.ToString();
    }

    public void CompleteLevel()
    {
        string levelName = SceneManager.GetActiveScene().name;
        string completionKey = levelName + "_completed";

        if (!PlayerPrefs.HasKey(completionKey)) // Only reward the player if the level hasn't been completed before
        {
            PlayerPrefs.SetInt(completionKey, 1);
            numberOfCoins += addCoin;
            PlayerPrefs.SetInt("NumberOfCoins", numberOfCoins);
            CoinsAdded.SetActive(true);
        }

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

    public void GameOver()
    {
        Time.timeScale = 0;

        GameOverscreen.SetActive(true);
    }
  
   
}
