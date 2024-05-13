using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_PlayerMovement : MonoBehaviour
{
    Rigidbody playerRb;
    Camera playerCam;
    [SerializeField] private float PlayerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerCam = Camera.main;

        toggleMouseLock();
        PlayerSpeed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        rotateCamera();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            PlayerSpeed = 3.5f;
        }
        else
        {
            PlayerSpeed = 2.0f;
        }
    }

    void movePlayer()
    {
        Vector3 inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        Vector3 moveVector = (playerCam.transform.right * inputVector.x) + (transform.forward * inputVector.z);
        playerRb.velocity = (moveVector.normalized * PlayerSpeed) + new Vector3(0.0f, playerRb.velocity.y - (playerRb.mass * Time.fixedDeltaTime), 0.0f);
    }

    void rotateCamera()
    {
        Vector3 mousePosInput = new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + mousePosInput.x, transform.eulerAngles.z);
        Camera.main.transform.eulerAngles = new Vector3(playerCam.transform.eulerAngles.x - mousePosInput.y, playerCam.transform.eulerAngles.y, playerCam.transform.eulerAngles.z);
    }

    void toggleMouseLock()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
