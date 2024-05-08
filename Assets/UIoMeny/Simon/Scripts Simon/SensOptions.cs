using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SensOptions : MonoBehaviour
{
    [SerializeField]
    Slider SensSlider;
    [SerializeField]
    Toggle YAxis;
    [SerializeField]
    Toggle XAxis;
    [SerializeField]
    TextMeshProUGUI SliderValue;

    bool InvertY;
    bool InvertX;
    float sens;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SliderValue.text = SensSlider.value.ToString("0.00");

        sens = SensSlider.value * 1000;

        if (YAxis.isOn)
        {
            InvertY = true;
        }
        
        if (XAxis.isOn)
        {
            InvertX = true;
        }
    }
}
