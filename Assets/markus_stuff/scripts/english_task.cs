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
        BroadcastMessage("start_englishTask",SendMessageOptions.RequireReceiver);
    }
    //called when task is completed
    void Englishtask_cleared()
    {
        taskDone();
    }
    //called when question script closes the task
    void close_englishTask()
    {
        endTask();
    }
    //give the reward for clearing the task
    public override void taskReward()
    {
        base.taskReward();
    }
    //end the task
    public override void endTask()
    {
        base.endTask();
        BroadcastMessage("end_englishTask",SendMessageOptions.RequireReceiver);
    }
}
