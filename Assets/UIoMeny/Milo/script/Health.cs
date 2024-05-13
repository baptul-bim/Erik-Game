using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Sprite twoHealth;
    public Sprite oneHealth;
    int tempHealth;

    // Update is called once per frame
    void Update()
    {
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
