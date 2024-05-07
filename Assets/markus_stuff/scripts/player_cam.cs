using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_cam : MonoBehaviour
{
    public float xSen;
    public float ySen;
    public Transform orientation;
    public float xRot;
    public float yRot;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    public void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSen;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySen;

        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(xRot, yRot, 0);
    }
}
