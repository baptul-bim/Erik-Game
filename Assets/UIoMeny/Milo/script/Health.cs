using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    // det börjar på full health så det behövs bara 2 i script
    public Sprite twoHealth;
    public Sprite oneHealth;
    public Image image;

    // byt ut detta med vad den faktiska variabeln för att ändra health är
    int tempHealth = 3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tempHealth--;
        }

        // om health är x/3 så byter det sprite till vi skrev där uppe. 
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
