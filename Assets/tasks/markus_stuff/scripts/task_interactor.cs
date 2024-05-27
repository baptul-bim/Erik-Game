using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class task_interactor : MonoBehaviour
{
    //put this script on the player cam

    public bool task;
    public LayerMask whatistask;
    // key to interact
    [SerializeField]
    public KeyCode interactKey;


    // Update is called once per frame
    void Update()
    { //keybind to open task 
        if (Input.GetKeyDown(interactKey))
        {
            doTask();
         
        }
      
    }
    //run when opening a task
    private void doTask()
    {
        //checks if there is a transform within reach
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            //checks that the transofm is a task
            task = Physics.Raycast(transform.position,transform.forward, 5, whatistask);
            if (task)
            {
                //tells the task to start
                     hit.transform.SendMessage("start_task",SendMessageOptions.RequireReceiver);
            }
       

        }
    }
}
