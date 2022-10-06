using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionMenu : MonoBehaviour
{

    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject fightMenu;
    [SerializeField] GameObject actionMenu;


    float x = 0f;
    float y = 0f;

    void Start()
    {
       actionSelector.gameObject.transform.position = new Vector3(1170f, 195f, 0f); 
    }


    void Update()
    {
        actionMenuSelection();
        menuOpener();
    }
    

    public void actionMenuSelection()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) && y < 1f)
        {
            y++;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && y == 1f)
        {
            y--;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && x < 1f)
        {
            x++;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) && x == 1f)
        {
            x--;
        }

        if(x == 0f && y == 0f)
        {
            actionSelector.transform.position = new Vector3(1170f, 195f, 0f);
        }

        if(x == 1f && y == 0f)
        {
            actionSelector.transform.position = new Vector3  (1560f, 195f, 0f);
        }

        if(x == 1f && y == 1f)
        {
            actionSelector.transform.position = new Vector3  (1560, 95, 0f);
        }

        if(x == 0f && y == 1f)
        {
            actionSelector.transform.position = new Vector3  (1170, 95, 0f);
        }
    }

    public void menuOpener()
    {
        if(Input.GetKeyDown(KeyCode.Z) && x == 0f && y == 0f)
        {
            fightMenu.gameObject.SetActive(true);
            //turn off the previous menu
            actionMenu.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Z) && x == 1f && y == 1f)
        {
            SceneManager.LoadScene("TestBase");
            //current issue, doesnt not return the user back to where they were originally
            //before the battle started
        }
    }


}
