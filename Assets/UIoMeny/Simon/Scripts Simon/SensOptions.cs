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
    TMP_InputField SilderNumber;
    [SerializeField]
    Toggle YAxis;
    [SerializeField]
    Toggle XAxis;
    [SerializeField]
    TextMeshProUGUI SliderValue;
    [SerializeField]
    TextMeshProUGUI text_;

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

    public void SliderChange()
    {
        SilderNumber.text = SensSlider.value.ToString("0");
    }

   
    public void TestInput()
    {
        float i = 0;
        float.TryParse(SilderNumber.text, out i);
        SensSlider.value = i;

    }
}
