using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eDrankLaunchTest : MonoBehaviour
{
    Rigidbody rb;
    public GameObject brokenWindow;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dir = (brokenWindow.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            rb.AddForce(dir * 1000);
        } 
    }
}
