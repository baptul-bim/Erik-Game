using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class task_script : MonoBehaviour
{
    public display_code DC;
    public randomCode_script RCS;
    [SerializeField]
    //stops cleared task from being opened
    public bool done;
    //task UI
    public Image image;
    private int NuumberFound;
    // Start is called before the first frame update
    void Start()
    {
        DC = FindObjectOfType<display_code>();
        RCS = FindObjectOfType<randomCode_script>();
        //redundancy
        done = false;
        NuumberFound = 0;
    }

    // Update is called once per frame
    public virtual void Update()
    {
      
        
    }
    //called to start the task
    void start_task()
    {
        print("recieved");
        startTask();
    }
    //starts the task
    public virtual void startTask()
    {
        if(!done)
        {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        image.enabled = true;
        }
        
    }
    //run when exiting the task without clearing it
    public virtual void endTask()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        image.enabled = false;
    }
    //give the reward for clearing the task
    public virtual void taskReward()
    {
        DC.displayCode[NuumberFound].text = new string("" + RCS.numbers[NuumberFound]);
        print("you get a thingy");
        NuumberFound += 1;
    }
    //run when task is compleated
    //run when task is compleat
    public virtual void taskDone()
    {
        done = true;
        taskReward();
        endTask();

    }


}
