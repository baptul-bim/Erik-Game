using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource anfåddClip;

    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    float stamina;
    [SerializeField] float maxStamina;
    [SerializeField] float staminaRegenSpeed;

    private float desiredMoveSpeed;
    private float lastDesiredMoveSpeed;

    public float speedIncreaseMultiplier;
    public float slopeIncreaseMultiplier;

    public float groundDrag;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    [Header("Hiding")]
    public bool hiding;
    public LayerMask hideRoof;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode jumpKeyController = KeyCode.JoystickButton0;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode sprintKeyController = KeyCode.JoystickButton8;
    public KeyCode crouchKey = KeyCode.LeftControl;
    public KeyCode crouchKeyController = KeyCode.JoystickButton1;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    public Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air
    }
    // Start is called before the first frame update
    void Start()
    {
        stamina = maxStamina;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        startYScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        //print(rb.velocity.magnitude.ToString("F1")); 
        if (state == MovementState.sprinting && stamina >= 0)
        {
            stamina -= Time.deltaTime;

            if (!anfåddClip.isPlaying)
            {
                anfåddClip.Play();
            }
        }
        else if (state != MovementState.sprinting && stamina <= maxStamina)
        {
            stamina += staminaRegenSpeed * Time.deltaTime;
        }

        grounded = Physics.Raycast(transform.position, Vector2.down, playerHeight * 0.5f + 0.2f, whatIsGround);//grounded is true if the raycast looking for whatIsGround layer is hitting ground
        hiding = Physics.Raycast(transform.position, Vector2.up, playerHeight * 0.5f + 0.2f, hideRoof);//checks if the roof of the hidingspot is above the player, Extend the hitbox of the hidingspot roof slitly to prevent the player from bugging into the roof

        if (grounded)//apply drag when grounded
        {
            rb.drag = groundDrag;
        }
        else//remove drag when airborn
        {
            rb.drag = 0;
        }

        PlayerInput();
        SpeedControl();
        StateHandler();
    }
    private void FixedUpdate()
    {
        movePlayer();
    }
    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if ((Input.GetKeyDown(jumpKey) || Input.GetKeyDown(jumpKeyController)) && readyToJump && grounded)//if hit jump button jump and reset the jump after a short delay
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);//reset jump after jumpCooldown delay
        }

        if ((Input.GetKeyDown(crouchKey) || Input.GetKeyDown(crouchKeyController)))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);//make the player shorter when crouching
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);//add force down so the player isn't floating
        }
        if (!hiding)
        {
            if ((!Input.GetKey(crouchKey) && !Input.GetKey(crouchKeyController)))
            {
                transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);//make the player normal hight when not crouching
            }
        }
    }
    private void StateHandler()
    {
        if ((grounded && Input.GetKey(crouchKey)) || hiding)//changes the state to crouching if crouch key is held or if the player is in a hidingspot 
        {
            state = MovementState.crouching;
            desiredMoveSpeed = crouchSpeed;
        }
        else if (grounded && (Input.GetKey(sprintKey) || Input.GetKey(sprintKeyController)) && stamina >= 0)
        {
            state = MovementState.sprinting;
            desiredMoveSpeed = sprintSpeed;
        }
        else if (grounded)
        {
            state = MovementState.walking;
            desiredMoveSpeed = walkSpeed;
        }
        else
        {
            state = MovementState.air;
        }

        if (Mathf.Abs(desiredMoveSpeed - lastDesiredMoveSpeed) > 4f && moveSpeed != 0)
        {
            StopAllCoroutines();
            StartCoroutine(SmoothlyLerpMoveSpeed());
        }
        else
        {
            moveSpeed = desiredMoveSpeed;
        }

        lastDesiredMoveSpeed = desiredMoveSpeed;
    }

    private IEnumerator SmoothlyLerpMoveSpeed()
    {
        float time = 0;
        float difference = Mathf.Abs(desiredMoveSpeed - moveSpeed);
        float startValue = moveSpeed;

        while (time < difference)//smoothly lerp movement speed to desired movement speed
        {
            moveSpeed = Mathf.Lerp(startValue, desiredMoveSpeed, time / difference);
            print("Checking if on slope:");
            if (OnSlope())
            {
                float slopeAngle = Vector3.Angle(Vector3.up, slopeHit.normal);
                
                float slopeAngleIncrease = 1 + (slopeAngle / 90f);

                time += Time.deltaTime * speedIncreaseMultiplier * slopeIncreaseMultiplier * slopeAngleIncrease;
            }
            else
            {
                time += Time.deltaTime * speedIncreaseMultiplier;
            }
            yield return null;
        }

        moveSpeed = desiredMoveSpeed;
    }
    private void movePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection(moveDirection) * moveSpeed * 20f, ForceMode.Force);//ands a force along the slope acording to the slope angle

            if (rb.velocity.y > 0)
            {
                //rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }

        else if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

        rb.useGravity = !OnSlope();//disables gravity if player is on a slope, so the player dose not slide while on a slope
    }
    private void SpeedControl()
    {
        if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed;
            }

        }

        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVel.magnitude > moveSpeed)//caps the speed at move speed
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }

    }
    private void Jump()
    {
        exitingSlope = true;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);//resets the velocity

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);//add force up
    }
    private void ResetJump()
    {
        readyToJump = true;

        exitingSlope = false;
    }
    public bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))//makes a raykast to get information of the ground the player is standing on
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);//calculates the angle of the object the raycast hits
            return angle < maxSlopeAngle && angle != 0;//return on slope as true if the angle of the ground below the player isn't 0 and is less than the max slope angle
        }

        return false;
    }

    public Vector3 GetSlopeMoveDirection(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal).normalized;//projects the normal move direction onto the slope
    }
}
