using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public TextMeshProUGUI timer;
   // public TMP_Text displayText;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 60;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //  displayText.SetText("Time Left: " + timeLeft);
        timer.text = timeLeft.ToString("0.00");
    }
}
