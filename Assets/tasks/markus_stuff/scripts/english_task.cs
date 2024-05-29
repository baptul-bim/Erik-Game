using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class English_task : task_script
{
    //starts the task
    public override void startTask()
    {
        base.startTask();
        //tells the questionscript to start
        if(!done)
        {
         BroadcastMessage("start_englishTask",SendMessageOptions.RequireReceiver);
        }
  
    }
    //called when task is completed
   public void Englishtask_cleared()
    {
        taskDone();
    }
    //called when question script closes the task
   public void close_englishTask()
    {
        endTask();
    }
    //give the reward for clearing the task

    //end the task
    public override void endTask()
    {
        base.endTask();
        BroadcastMessage("end_englishTask",SendMessageOptions.RequireReceiver);
    }
}
