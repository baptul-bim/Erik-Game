using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float tempStamina;
    public float tempMaxStamina;

    [SerializeField]
    public Image staminaSlider;    

    void Update()
    {
        /*
        // om du anv�nder shift (eller vilken knapp man anv�nder f�r att springa) s� g�r v�rdet p� slidern (stamina bar) ner
        if (Input.GetKey(KeyCode.LeftShift))
        {
            tempStamina -= Time.deltaTime;
        }
        else // om du sl�pper shift �kar v�rdet tillbaka till max
        {
            tempStamina += 0.5f * Time.deltaTime;
        }

        tempStamina = Mathf.Clamp(tempStamina, 0, tempMaxStamina);
        staminaSlider.value = tempStamina;
        */

        staminaSlider.fillAmount = FindObjectOfType<PlayerMove>().stamina/3;

        if (FindObjectOfType<PlayerMove>().stamina <= 0)
        {
            staminaSlider.fillAmount = 0;
        }


    }
}