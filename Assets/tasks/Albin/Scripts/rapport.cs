using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rapport : MonoBehaviour
{
    [SerializeField]
    GameObject rapportUI;
    [SerializeField]
    GameObject fardig_rapportUI;
    [SerializeField]
    GameObject facitUI;
    [SerializeField]
    GameObject text;
    [SerializeField]
    GameObject tip;
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
    [SerializeField]
    GameObject row11;
    [SerializeField]
    GameObject row12;
    [SerializeField]
    GameObject row13;
    [SerializeField]
    GameObject row14;
    [SerializeField]
    GameObject row15;
    [SerializeField]
    GameObject row16;
    [SerializeField]
    GameObject row17;
    [SerializeField]
    GameObject row18;
    [SerializeField]
    GameObject row19;
    [SerializeField]
    GameObject row20;
    [SerializeField]
    GameObject row21;
    [SerializeField]
    GameObject row22;
    [SerializeField]
    GameObject row23;
    [SerializeField]
    GameObject row24;
    [SerializeField]
    GameObject row25;
    [SerializeField]
    GameObject row26;
    [SerializeField]
    GameObject row27;
    [SerializeField]
    GameObject row28;
    [SerializeField]
    GameObject row29;
    [SerializeField]
    GameObject row30;
    [SerializeField]
    GameObject row31;
    [SerializeField]
    GameObject row32;
    [SerializeField]
    GameObject row33;
    [SerializeField]
    GameObject row34;
    [SerializeField]
    GameObject row35;
    [SerializeField]
    GameObject row36;
    [SerializeField]
    GameObject row37;



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
        row11.SetActive(false);
        row12.SetActive(false);
        row13.SetActive(false);
        row14.SetActive(false);
        row15.SetActive(false);
        row16.SetActive(false);
        row17.SetActive(false);
        row18.SetActive(false);
        row19.SetActive(false);
        row20.SetActive(false);
        row21.SetActive(false);
        row22.SetActive(false);
        row23.SetActive(false);
        row24.SetActive(false);
        row25.SetActive(false);
        row26.SetActive(false);
        row27.SetActive(false);
        row28.SetActive(false);
        row29.SetActive(false);
        row30.SetActive(false);
        row31.SetActive(false);
        row32.SetActive(false);
        row33.SetActive(false);
        row34.SetActive(false);
        row35.SetActive(false);
        row36.SetActive(false);
        row37.SetActive(false);
        fardig_rapportUI.SetActive(false);
        rapportUI.SetActive(false);
        facitUI.SetActive(false);
        text.SetActive(false);
        tip.SetActive(false);
    }

    void start_rapport_task()
    {
        if (facit == false)
        {
            rapportUI.SetActive(true);
            text.SetActive(true);
            tip.SetActive(true);
        }
        if (facit == true)
        {
            tasking = true;
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
            row11.SetActive(true);
            row12.SetActive(true);
            row13.SetActive(true);
            row14.SetActive(true);
            row15.SetActive(true);
            row16.SetActive(true);
            row17.SetActive(true);
            row18.SetActive(true);
            row19.SetActive(true);
            row20.SetActive(true);
            row21.SetActive(true);
            row22.SetActive(true);
            row23.SetActive(true);
            row24.SetActive(true);
            row25.SetActive(true);
            row26.SetActive(true);
            row27.SetActive(true);
            row28.SetActive(true);
            row29.SetActive(true);
            row30.SetActive(true);
            row31.SetActive(true);
            row32.SetActive(true);
            row33.SetActive(true);
            row34.SetActive(true);
            row35.SetActive(true);
            row36.SetActive(true);
            row37.SetActive(true);
            fardig_rapportUI.SetActive(true);
            facitUI.SetActive(true);
        }
    }
    void end_rapport_task()
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
        row11.SetActive(false);
        row12.SetActive(false);
        row13.SetActive(false);
        row14.SetActive(false);
        row15.SetActive(false);
        row16.SetActive(false);
        row17.SetActive(false);
        row18.SetActive(false);
        row19.SetActive(false);
        row20.SetActive(false);
        row21.SetActive(false);
        row22.SetActive(false);
        row23.SetActive(false);
        row24.SetActive(false);
        row25.SetActive(false);
        row26.SetActive(false);
        row27.SetActive(false);
        row28.SetActive(false);
        row29.SetActive(false);
        row30.SetActive(false);
        row31.SetActive(false);
        row32.SetActive(false);
        row33.SetActive(false);
        row34.SetActive(false);
        row35.SetActive(false);
        row36.SetActive(false);
        row37.SetActive(false);
        fardig_rapportUI.SetActive(false);
        rapportUI.SetActive(false);
        facitUI.SetActive(false);
        text.SetActive(false);
        tip.SetActive(false);
    }

    void cleared_rapport_task()
    {
        SendMessageUpwards("rapport_task_cleared",SendMessageOptions.RequireReceiver);
    }
    // Update is called once per frame
    void Update()
    {
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
            }
            if (typing >= 12)
            {
                row11.SetActive(false);
            }
            if (typing >= 13)
            {
                row12.SetActive(false);
            }
            if (typing >= 14)
            {
                row13.SetActive(false);
            }
            if (typing >= 15)
            {
                row14.SetActive(false);
            }
            if (typing >= 16)
            {
                row15.SetActive(false);
            }
            if (typing >= 17)
            {
                row16.SetActive(false);
            }
            if (typing >= 18)
            {
                row17.SetActive(false);
            }
            if (typing >= 19)
            {
                row18.SetActive(false);
            }
            if (typing >= 20)
            {
                row19.SetActive(false);
            }
            if (typing >= 21)
            {
                row20.SetActive(false);
            }
            if (typing >= 22)
            {
                row21.SetActive(false);
            }
            if (typing >= 23)
            {
                row22.SetActive(false);
            }
            if (typing >= 24)
            {
                row23.SetActive(false);
            }
            if (typing >= 25)
            {
                row24.SetActive(false);
            }
            if (typing >= 26)
            {
                row25.SetActive(false);
            }
            if (typing >= 27)
            {
                row26.SetActive(false);
            }
            if (typing >= 28)
            {
                row27.SetActive(false);
            }
            if (typing >= 29)
            {
                row28.SetActive(false);
            }
            if (typing >= 30)
            {
                row29.SetActive(false);
            }
            if (typing >= 31)
            {
                row30.SetActive(false);
            }
            if (typing >= 32)
            {
                row31.SetActive(false);
            }
            if (typing >= 33)
            {
                row32.SetActive(false);
            }
            if (typing >= 34)
            {
                row33.SetActive(false);
            }
            if (typing >= 35)
            {
                row34.SetActive(false);
            }
            if (typing >= 36)
            {
                row35.SetActive(false);
            }
            if (typing >= 37)
            {
                row36.SetActive(false);
            }
            if (typing >= 38)
            {
                row37.SetActive(false);
                cleared_rapport_task();
                fardig_rapportUI.SetActive(false);
                rapportUI.SetActive(false);
                facitUI.SetActive(false);
                text.SetActive(false);
            }
        }
    }
}
