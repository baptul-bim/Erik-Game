using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public int maxStamina;
    public int currentStamina;

    public Slider slider;

    void Start()
    {
        currentStamina = maxStamina;
        slider.maxValue = maxStamina;
        slider.value = currentStamina;
    }

    public void whileRunning()
    {
        slider.value = currentStamina;
    }

    void Update()
    {
        
    }
}
