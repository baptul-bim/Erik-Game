using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCode_script : MonoBehaviour
{
    public string code;
    public int number1;
    public int number2;
    public int number3;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void generateCode()
    {
        System.Random rng = new System.Random();
        number1 = rng.Next(0, 10);
        number2 = rng.Next(0, 10);
        number3 = rng.Next(0, 10);
        code =""+number1 + number2 + number3;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
