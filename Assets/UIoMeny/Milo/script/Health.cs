using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    // det börjar på full health så det behövs bara 2 i script
    public Sprite twoHealth;
    public Sprite oneHealth;
    
    // byt ut detta med vad den faktiska variabeln för att ändra health är
    int tempHealth;

    // Update is called once per frame
    void Update()
    {
        // om health är x/3 så byter det sprite till vi skrev där uppe. 
        if (tempHealth == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = twoHealth;
        }

        if (tempHealth == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = oneHealth;
        }
    }
}
