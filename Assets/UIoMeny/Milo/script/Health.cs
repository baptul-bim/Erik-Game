using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    // det börjar på full health så det behövs bara 2 i script
    public Sprite twoHealth;
    public Sprite oneHealth;

    // byt ut detta med vad den faktiska variabeln för att ändra health är
    int health;

    [SerializeField]
    public Image hp_sprite;


    // Update is called once per frame
    void Update()
    {
        // om health är x/3 så byter det sprite till vi skrev där uppe. 

        print(this.gameObject.GetComponent<SpriteRenderer>().sprite);
        if (FindObjectOfType<PlayerHealthManager>().heartsLeft == 2)
        {

            hp_sprite.sprite = twoHealth;
        }

        if (FindObjectOfType<PlayerHealthManager>().heartsLeft == 1)
        {
            hp_sprite.sprite = oneHealth;
        }
        
    }
}
