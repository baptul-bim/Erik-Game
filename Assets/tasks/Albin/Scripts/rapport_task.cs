using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rapport_task : task_script
{
    // Start is called before the first frame update
    public override void startTask()
    {
        base.startTask();
        if (!done)
        {
            BroadcastMessage("start_rapport_task",SendMessageOptions.RequireReceiver);
        }
    }
    public override void endTask()
    {
        base.endTask();
        BroadcastMessage("end_rapport_task",SendMessageOptions.RequireReceiver);
    }

    // Update is called once per frame
    void rapport_task_end()
    {
        endTask();
    }

    void rapport_task_cleared()
    {
        taskDone();
    }
}
