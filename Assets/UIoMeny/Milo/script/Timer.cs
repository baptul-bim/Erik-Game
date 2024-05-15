using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public TextMeshProUGUI timer;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 60;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        // mängden nollor efter 0. är mängden decimaler. 
        timer.text = timeLeft.ToString("Time Left: " + "0.00");
    }
}
