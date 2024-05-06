using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
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

    public void Quit()
    {
        Application.Quit();
        Debug.Log("player quit");
    }
}
