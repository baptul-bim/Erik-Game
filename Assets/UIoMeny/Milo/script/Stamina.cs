using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float tempStamina;
    public float tempMaxStamina;

    public Slider staminaSlider;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            tempStamina -= Time.deltaTime;
        }
        else
        {
            tempStamina += 0.5f * Time.deltaTime;
        }

        tempStamina = Mathf.Clamp(tempStamina, 0, tempMaxStamina);

        staminaSlider.value = tempStamina;
    }
}
