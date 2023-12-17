using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //Add avatars here
    public GameObject avatar1, avatar2, avatar3,avatar4;
    public bool avatar1Active = true;
    public bool avatar2Active = true;
    public bool avatar3Active = true;
    public bool avatar4Active = true;

    public GameObject PauseMenuScreen;
    public GameObject GameOverUi;





    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    private int CoinCount;

    private int DiamondCount;

    // set the variables
    [SerializeField] private Transform lifeParent;

    [SerializeField] private GameObject lifePrefab;


    [SerializeField] private Transform slifeParent;

    [SerializeField] private GameObject slifePrefab;

    [SerializeField] private Transform zlifeParent;

    [SerializeField] private GameObject zlifePrefab;

    [SerializeField] private Transform glifeParent;

    [SerializeField] private GameObject glifePrefab;


    private Stack<GameObject> zlives = new Stack<GameObject>();

    private Stack<GameObject> lives = new Stack<GameObject>();

    private Stack<GameObject> slives = new Stack<GameObject>();

    private Stack<GameObject> glives = new Stack<GameObject>();


    [SerializeField] private TMP_Text CoinText;

    [SerializeField] private TMP_Text DiamondText;

    // coin function working for all players
    public void AddCoin()
    {
        CoinCount++;
        CoinText.text = CoinCount.ToString();
    }

    public void AddDiamond()
    {
        DiamondCount++;
        DiamondText.text = DiamondCount.ToString();
    }
    // robot functions
    public void AddLife(int amount)
    {
        if (avatar2Active)
        {
            for (int i = 0; i < amount; i++)
            {
                lives.Push(Instantiate(lifePrefab, lifeParent));

            }

            

        }
    }


    public void RemoveLife()
    {
        if (avatar2Active)
        {
            Destroy(lives.Pop());
        }

    }

    // shadow functions
    public void AddSLife(int amount)
    {
        if (avatar1Active)
        {
            for (int i = 0; i < amount; i++)
            {
                slives.Push(Instantiate(slifePrefab, slifeParent));

            }
            
        }
       
    }

    public void RemoveSLife()
    {
        if (avatar1Active)
        {
            Destroy(slives.Pop());
        }
        
    }

    public void AddZLife(int amount)
    {
        if (avatar3Active)
        {
            for (int i = 0; i < amount; i++)
            {
                zlives.Push(Instantiate(zlifePrefab, zlifeParent));


            }

        }

    }

    public void RemoveZLife()
    {
        if (avatar3Active)
        {
            Destroy(zlives.Pop());
        }

    }

    public void AddGLife(int amount)
    {
        if (avatar4Active)
        {
            for (int i = 0; i < amount; i++)
            {
                glives.Push(Instantiate(glifePrefab, glifeParent));


            }

        }

    }

    public void RemoveGLife()
    {
        if (avatar4Active)
        {
            Destroy(glives.Pop());
        }

    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenuScreen.SetActive(false);
    }

    public void GameOver()
    {

        GameOverUi.SetActive(true);
        
        
    }

 
}