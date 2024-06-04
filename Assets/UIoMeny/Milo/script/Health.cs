using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    // det b�rjar p� full health s� det beh�vs bara 2 i script
    public Sprite twoHealth;
    public Sprite oneHealth;
    public Image image;

    // byt ut detta med vad den faktiska variabeln f�r att �ndra health �r
    int tempHealth = 3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tempHealth--;
        }

        // om health �r x/3 s� byter det sprite till vi skrev d�r uppe. 
        if (tempHealth == 2)
        {
            image.GetComponent<Image>().sprite = twoHealth;
        }

        if (tempHealth == 1)
        {
            image.GetComponent<Image>().sprite = oneHealth;
        }
    }
}
