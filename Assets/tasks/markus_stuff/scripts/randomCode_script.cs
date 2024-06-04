using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCode_script : MonoBehaviour
{
    public string code;
    public int number1;
    public int number2;
    public int number3;
    public int[] numbers = new int[3];
    // Start is called before the first frame update
    void Start()
    {
        generateCode();
    }
    public void generateCode()
    {
        System.Random rng = new System.Random();
        
        for(int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = rng.Next(0, 10);
        }
        number1 = numbers[0];
        number2 = numbers[1];
        number3 = numbers[2];
        code =""+number1 + number2 + number3;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
