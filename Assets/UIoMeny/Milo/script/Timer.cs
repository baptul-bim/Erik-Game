using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 60;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
    }
}
