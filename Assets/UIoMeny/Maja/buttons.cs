using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("placeholder scene");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("player quit");
    }
}
