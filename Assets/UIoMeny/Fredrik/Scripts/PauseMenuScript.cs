using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    //all of the GameObjects that the pause menu consists of
    public GameObject pauseMenu;
    public GameObject mainPauseMenu;
    public GameObject optionsMenu;
    public GameObject optionsMainMenu;
    public GameObject sensitivityMenu;
    public GameObject audioMenu;
    public GameObject graphicsMenu;
    public GameObject aYSMainMenuScreen;
    public GameObject aYSQuitScreen;

    // Update is called once per frame
    void Update()
    {
        //enables or disables the menu, or goes one step back if you are in a specific part of the pause menu. Executed very poorly
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.activeSelf == false)
            {
                pauseMenu.SetActive(true);

            }
            else if(pauseMenu.activeSelf == true)
            {
                if(optionsMenu.activeSelf == true)
                {
                    if(optionsMainMenu.activeSelf == true)
                    {
                        optionsMenu.SetActive(false);
                        mainPauseMenu.SetActive(true);
                    }
                    else if(sensitivityMenu.activeSelf == true)
                    {
                        sensitivityMenu.SetActive(false);
                        optionsMainMenu.SetActive(true);
                    }
                    else if (audioMenu.activeSelf == true)
                    {
                        audioMenu.SetActive(false);
                        optionsMainMenu.SetActive(true);
                    }
                    else if (graphicsMenu.activeSelf == true)
                    {
                        graphicsMenu.SetActive(false);
                        optionsMainMenu.SetActive(true);
                    }
                    else
                    {
                        optionsMenu.SetActive(false);
                        mainPauseMenu.SetActive(true);
                    }
                }
                else if (aYSMainMenuScreen.activeSelf == true)
                {
                    aYSMainMenuScreen.SetActive(false);
                    mainPauseMenu.SetActive(true);
                }
                else if(aYSQuitScreen.activeSelf == true)
                {
                    aYSQuitScreen.SetActive(false);
                    mainPauseMenu.SetActive(true);
                }
                else
                {
                    pauseMenu.SetActive(false);
                }
            }
        }
    }

    //Switches the scene to the main menu
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Closes the application
    public void QuitGame()
    {
            Application.Quit();
    }
}
