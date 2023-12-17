using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public Transform Shadow; // The other character that should have the same position

    public Transform HumanShadow; // The other character that should have the same position

    public Transform Zombie; // The other character that should have the same position

    public Transform Ghost; // The other character that should have the same position

    public GameObject prelives, preslives,prezlives , preglives;// the health bars

    public GameObject avatar1, avatar2,avatar3,avatar4;//characters

    private Enemy enemy;
    
    public bool avatar1Active = true;
  
    public bool avatar3Active = true;

    public bool avatar4Active = true;

    // Start is called before the first frame update
    void Start()
    {
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        preslives.gameObject.SetActive(true);
        prelives.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);
        prezlives.gameObject.SetActive(false);
        avatar3Active = false;
        avatar4Active = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) 
        {
            SwitchPlayer();
            avatar3Active = false;// enemies should be disabled when switching between forms
            avatar4Active = false;
        }

        if (Input.GetKeyDown(KeyCode.P) )
        {
          
                SwitchEnemyZ();
            avatar4Active = false;
            avatar1Active = false;

            // Show the Button only when he is killed

        }
        if (Input.GetKeyDown(KeyCode.L))
        {

            SwitchEnemyG();
            avatar3Active = false;
            avatar1Active = false;

            // Show the Button only when he is killed

        }
        //switch betwwen forms
        void SwitchPlayer()
        {
            if (avatar1Active)
            {
                avatar1Active = false;
                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(true);
                preslives.gameObject.SetActive(false);
                prelives.gameObject.SetActive(true);
                avatar3.gameObject.SetActive(false);
                prezlives.gameObject.SetActive(false);
                avatar4.gameObject.SetActive(false);
                preglives.gameObject.SetActive(false);
            }

            else if(!avatar1Active)
            {
                
                avatar1Active = true;
                avatar1.gameObject.SetActive(true);
                avatar2.gameObject.SetActive(false);
                preslives.gameObject.SetActive(true);
                prelives.gameObject.SetActive(false);
                avatar3.gameObject.SetActive(false);
                prezlives.gameObject.SetActive(false);
                avatar4.gameObject.SetActive(false);
                preglives.gameObject.SetActive(false);

            }
        }
     



        
        if (avatar1Active && !avatar3Active && !avatar4Active)
        {

            // Set the position of this character to be the same as the other characters
            HumanShadow.transform.position = Shadow.position;
            Zombie.transform.position = Shadow.position;
            Ghost.transform.position = Shadow.position;

        }

         if (!avatar1Active && !avatar3Active && !avatar4Active)
        {

            // Set the position of this character to be the same as the other characters
            Shadow.transform.position = HumanShadow.position;
            Zombie.transform.position = HumanShadow.position;
            Ghost.transform.position = HumanShadow.position;
        }

        if ( avatar3Active)
        {
            // Set the position of this character to be the same as the other characters
            HumanShadow.transform.position = Zombie.position;
            Shadow.transform.position = Zombie.position;
            Ghost.transform.position = Zombie.position;

        }

        if (avatar4Active)
        {
            // Set the position of this character to be the same as the other characters
            HumanShadow.transform.position = Ghost.position;
            Shadow.transform.position = Ghost.position;
            Zombie.transform.position = Ghost.position;

        }

    }

    // Switch to the enemy
    public void   SwitchEnemyZ()
    {


        avatar3Active = true;
        
        avatar1.gameObject.SetActive(false);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(true);
        avatar4.gameObject.SetActive(false);
        preslives.gameObject.SetActive(false);
        prelives.gameObject.SetActive(false);
        prezlives.gameObject.SetActive(true);
        preglives.gameObject.SetActive(false);

    }

    public void SwitchEnemyG()
    {


        avatar4Active = true;
        
        
        avatar1.gameObject.SetActive(false);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);
        avatar4.gameObject.SetActive(true);
        preslives.gameObject.SetActive(false);
        prelives.gameObject.SetActive(false);
        prezlives.gameObject.SetActive(false);
        preglives.gameObject.SetActive(true);


    }


}
