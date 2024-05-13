using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float tempStamina;
    public float tempMaxStamina;

    public Slider staminaSlider;

    void Update()
    {
        // om du använder shift (eller vilken knapp man använder för att springa) så går värdet på slidern (stamina bar) ner
        if (Input.GetKey(KeyCode.LeftShift))
        {
            tempStamina -= Time.deltaTime;
        }
        else // om du släpper shift ökar värdet tillbaka till max
        {
            tempStamina += 0.5f * Time.deltaTime;
        }

        tempStamina = Mathf.Clamp(tempStamina, 0, tempMaxStamina);
        staminaSlider.value = tempStamina;
    }
}
