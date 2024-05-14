using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AudioSliderAndToggle : MonoBehaviour
{
    float Audio;
    float silderValue;

   

    [SerializeField]
    Slider vSlider;

    [SerializeField]
    Toggle vToggle;

    [SerializeField]
    TextMeshProUGUI VisableValue;

    bool Active;
    public void OnSliderChange() 
    {
        if (vSlider.value != 0)
        {
            vToggle.isOn = false;
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        VisableValue.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        VisableValue.text = vSlider.value.ToString();
        
        Audio = vSlider.value;
        if (vToggle.isOn == true)
        {
            vSlider.value = 0;
            VisableValue.text = "0";
        }
    }

   
}
