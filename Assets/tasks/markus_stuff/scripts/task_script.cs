using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class task_script : MonoBehaviour
{
    //stops cleared task from being opened
    public bool done;
    //task UI
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        //redundancy
        done = false;
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
        print("you get a thingy");
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
