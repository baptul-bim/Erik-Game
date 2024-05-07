using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class task_script : MonoBehaviour
{
    public bool done;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
      if(Input.GetKey(KeyCode.E))
        {
            endTask();
        }
    }
    void start_task()
    {
        print("recieved");
        startTask();
    }
    //starts the task
    public virtual void startTask()
    {
        image.enabled = true;
    }
    //run when exiting the task without clearing it
    public virtual void endTask()
    {
        image.enabled = false;
    }
    public virtual void taskReward()
    {
        print("you get a thingy");
    }
    //run when task is compleated
    public virtual void taskDone()
    {
        done = true;
        taskReward();
        endTask();

    }


}
