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

    // byt ut detta med vad den faktiska variabeln f�r att �ndra health �r
    int health;

    [SerializeField]
    public Image hp_sprite;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tempHealth--;
        }

        // om health �r x/3 s� byter det sprite till vi skrev d�r uppe. 

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
