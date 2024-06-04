using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class display_code : MonoBehaviour
{
    public TextMeshProUGUI[] displayCode;
    // Start is called before the first frame update
    void Start()
    {
        displayCode[0].text = "";
        displayCode[1].text = "";
        displayCode[2].text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
