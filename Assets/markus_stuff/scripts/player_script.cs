using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{

    [Header("Ground Check")]
    public float playerTall;
    public LayerMask WhatGround;
    public bool grounded;
    [Header("Movement")]
    public float speed;
    public float groundDrag;

    [Header("Keybinds")]

    public Transform ori;
    public float Xin;
    public float Yin;

    public Vector3 moveDir;

    Rigidbody Rb;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        speedLimit();
        grounded = Physics.Raycast(transform.position, Vector3.down, playerTall * 1 + 0.2f, WhatGround);
        myInput();
        if (grounded)
        {
            Rb.drag = groundDrag;
            
        }
        else
        {
            Rb.drag = 0;
        }
        
    }
    private void FixedUpdate()
    {
        
        move();
    }
    public void myInput()
    {
      
        Xin = Input.GetAxisRaw("Horizontal");
        Yin = Input.GetAxisRaw("Vertical");
    }
    public void move()
    {
        moveDir = ori.forward * Yin + ori.right * Xin;
        if (grounded)
        {
            Rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
        }
     

    }
    private void speedLimit()
    {
        Vector3 flatVel = new Vector3(Rb.velocity.x, 0f, Rb.velocity.z);
        if (flatVel.magnitude > speed)
        {
            Vector3 limVel = flatVel.normalized * speed;
            Rb.velocity = new Vector3(limVel.x, Rb.velocity.y, limVel.z);
        }
    }
   
}
