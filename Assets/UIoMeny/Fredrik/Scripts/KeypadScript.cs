using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadScript : MonoBehaviour
{
    public string inputedCode;
    public int desiredCode;
    public TextMeshProUGUI inputText;
    public GameObject mainKeypad;

    //closes the kypad menu
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainKeypad.SetActive(false);
        }
    }

    //adds the number of the button pressed to a string, therefore placing it at the end of a string (1+1=11 type shit) unless it already has 3 digits
    public void ButtonInput(int n)
    {
        if(inputedCode.Length < 3)
        {
            inputedCode += n;
            inputText.text = inputedCode;
        }
    }

    public void CancelButton()
    {
        inputedCode = "";
        inputText.text = "";
    }

    //checks if the code is correct, and clears the text if not
    public void CheckButton()
    {
        if(inputedCode == "")
        {
            return;
        }

        if(int.Parse(inputedCode) == desiredCode)
        {
            TemporaryWinTrigger();
        }
        else
        {
            inputedCode = "";
            inputText.text = "";

            //error sound effect??? potentially
        }
    }

    //change this to whatever is supposed to happen when you enter the correct code
    void TemporaryWinTrigger()
    {
        //input text can be changed to a 3 letter word upon inputing the correct code if you want to. Cant be longer than 3 characters tho
        inputText.text = "Win";
    }

}
