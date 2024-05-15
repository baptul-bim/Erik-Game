using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicsSettings : MonoBehaviour
{
    [SerializeField]
    Slider FOVSlider;
    [SerializeField]
    TMP_InputField FOVInput;

    public float FOV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FOV = FOVSlider.value;
    }

    public void OnSliderChange() 
    {
        FOVInput.text = FOVSlider.value.ToString("0");

    }

    public void WhenInput()
    {
        float i = 0;
        float.TryParse(FOVInput.text, out i);
        FOVSlider.value = i;

    }
}
