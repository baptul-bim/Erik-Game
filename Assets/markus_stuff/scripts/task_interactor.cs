using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task_interactor : MonoBehaviour
{

    public bool task;
    public LayerMask whatistask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            doTask();
         
        }
    }
    private void doTask()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            print("sent");
            task = Physics.Raycast(transform.position, transform.forward, 5, whatistask);
            if (task)
            {
                     hit.transform.SendMessage("start_task");
            }
       

        }
    }
}
