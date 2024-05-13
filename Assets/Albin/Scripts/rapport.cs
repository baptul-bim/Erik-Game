using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rapport : MonoBehaviour
{
    [SerializeField]
    GameObject rapportUI;
    [SerializeField]
    GameObject färdig_rapportUI;
    [SerializeField]
    GameObject facitUI;
    [SerializeField]
    GameObject text;
    [SerializeField]
    GameObject row1;
    [SerializeField]
    GameObject row2;
    [SerializeField]
    GameObject row3;
    [SerializeField]
    GameObject row4;
    [SerializeField]
    GameObject row5;
    [SerializeField]
    GameObject row6;
    [SerializeField]
    GameObject row7;
    [SerializeField]
    GameObject row8;
    [SerializeField]
    GameObject row9;
    [SerializeField]
    GameObject row10;



    public int typing = 0;
    public bool facit;
    public bool tasking;
    public bool done;
    // Start is called before the first frame update
    void Start()
    {
        tasking = false;
        done = false;
        facit = false;

        row1.SetActive(false);
        row2.SetActive(false);
        row3.SetActive(false);
        row4.SetActive(false);
        row5.SetActive(false);
        row6.SetActive(false);
        row7.SetActive(false);
        row8.SetActive(false);
        row9.SetActive(false);
        row10.SetActive(false);
        färdig_rapportUI.SetActive(false);
        rapportUI.SetActive(false);
        facitUI.SetActive(false);
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            tasking = true;
            if (facit == false)
            {
                rapportUI.SetActive(true);
                text.SetActive(true);
            }
            if (facit == true) 
            {
                row1.SetActive(true);
                row2.SetActive(true);
                row3.SetActive(true);
                row4.SetActive(true);
                row5.SetActive(true);
                row6.SetActive(true);
                row7.SetActive(true);
                row8.SetActive(true);
                row9.SetActive(true);
                row10.SetActive(true);
                färdig_rapportUI.SetActive(true);
                facitUI.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            typing = 0;
            tasking = false;
            row1.SetActive(false);
            row2.SetActive(false);
            row3.SetActive(false);
            row4.SetActive(false);
            row5.SetActive(false);
            row6.SetActive(false);
            row7.SetActive(false);
            row8.SetActive(false);
            row9.SetActive(false);
            row10.SetActive(false);
            färdig_rapportUI.SetActive(false);
            rapportUI.SetActive(false);
            facitUI.SetActive(false);
            text.SetActive(false);
        }
        if (tasking == true)
        {
            if (Input.anyKeyDown)
            {
                typing += 1;
            }
            if (typing >= 2)
            {
                row1.SetActive(false);
            }
            if (typing >= 3)
            {
                row2.SetActive(false);
            }
            if (typing >= 4)
            {
                row3.SetActive(false);
            }
            if (typing >= 5)
            {
                row4.SetActive(false);
            }
            if (typing >= 6)
            {
                row5.SetActive(false);
            }
            if (typing >= 7)
            {
                row6.SetActive(false);
            }
            if (typing >= 8)
            {
                row7.SetActive(false);
            }
            if (typing >= 9)
            {
                row8.SetActive(false);
            }
            if (typing >= 10)
            {
                row9.SetActive(false);
            }
            if (typing >= 11)
            {
                row10.SetActive(false);
                done = true;
                färdig_rapportUI.SetActive(false);
                rapportUI.SetActive(false);
                facitUI.SetActive(false);
                text.SetActive(false);
            }
        }
    }
}
