using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Pathfinding.Util;
public class ErikManager : MonoBehaviour
{
    [SerializeField] private GameObject ErikObj;
    [SerializeField] private AIDestinationSetter ErikDestinationSetter;
    [SerializeField] private AIPath ErikAIPath;
    [SerializeField] private string ErikCurrentState;
 

    private Collider erikCollider;
    private Camera playerCam;
    private Plane[] cameraFrustum;

    private string[] avalibleStates = { "Chase", "Lurk", "Patrol", "Idle", "Flee" };

    [SerializeField] private bool PlayerInSight;
    private float timeSinceSeenPlayer;

    [SerializeField] private float MaxChaseTime;

    [SerializeField] private float AngerValue;
    //private List<Action> AvalibleStates;

    [SerializeField] private GameObject ErikLocalTargetObj;

    private Vector3 lastAnchor;
    private Vector3 previousDestination;


    // Start is called before the first frame update
    void Start()
    {
        ErikDestinationSetter = ErikObj.GetComponent<AIDestinationSetter>();
        ErikAIPath = ErikObj.GetComponent<AIPath>();

        erikCollider = ErikObj.GetComponentInChildren<Collider>();
        playerCam = Camera.main;

        lastAnchor = ErikObj.transform.position;
        previousDestination = ErikAIPath.autoRepath.lastDestination;
        SetErikState("Patrol");
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSeenPlayer += Time.deltaTime;
        

        if (PlayerInSight)
        {
            timeSinceSeenPlayer = 0.0f;
        }

        if (ErikCurrentState == "Chase" && timeSinceSeenPlayer > MaxChaseTime) //De-aggros Erik after having chased the player for a certian time without seeing them.
        {
            SetErikState("Patrol");
        }


        if (int.TryParse(Input.inputString, out int numberPressed)) //Debug tool: Changes Erik's speed to the corresponding numeric key pressed.
        {
            SetErikSpeed(numberPressed);
        }

        if (erikInView())
        {


            //print(Vector3.Distance(playerCam.transform.position + playerCam.transform.forward, ErikObj.transform.position) + " and " + (Vector3.Distance(playerCam.transform.position, ErikObj.transform.position) - 0.75f));

            if (Vector3.Distance(playerCam.transform.position + playerCam.transform.forward, ErikObj.transform.position) < (Vector3.Distance(playerCam.transform.position, ErikObj.transform.position) - 0.75f))
            {
                SetErikState("Flee");
            }
            else if (ErikCurrentState != "Flee") 
            {
                SetErikState("Idle");
                print("Erik looks at you.");
                ErikObj.transform.LookAt(playerCam.transform);
            }

        }
        else
        {
            SetErikState("Patrol");

            if (previousDestination != ErikAIPath.autoRepath.lastDestination)
            {
                lastAnchor = ErikObj.transform.position;
                previousDestination = ErikAIPath.autoRepath.lastDestination;
                print("placed new anchor");
            }

        }

       
    }

   



    /// <summary>
    /// Changes the current state of the Erik AI.
    /// <list type="States">
    /// Avalible States:
    /// <item>Chase, Idle, Patrol, Lurk</item>
    /// </list>
    /// </summary>
    /// <param name="State"></param>
    public void SetErikState(string stateName)
    {
     
        foreach (string state in avalibleStates)
        {
            if (state == stateName)
            {
                Invoke(stateName, 0.0f);
                ErikCurrentState = stateName;
            }
        }
        

    }

    public void SetErikTarget(GameObject TargetPointObj)
    {
        ErikDestinationSetter.target = TargetPointObj.transform;
    }

    
    private bool erikInView()
    {
        Bounds erikColliderBounds = erikCollider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(playerCam);

        RaycastHit hit;
        Physics.Raycast(playerCam.transform.position, (ErikObj.transform.position - playerCam.transform.position).normalized, out hit, Vector3.Distance(ErikObj.transform.position, playerCam.transform.position));


        if (GeometryUtility.TestPlanesAABB(cameraFrustum, erikColliderBounds) && (hit.collider == null || hit.collider != null && hit.collider.gameObject.layer != LayerMask.NameToLayer("Obstacle")))
        {
            print("Can see erik");
            return true;

        }
        else
        {
            print("Cannot see erik");
            return false;
        }

    }

    public void SetErikSpeed(float MaxSpeed = 1, bool CanMove = true) 
    {
        //If method is called without specifying parameters, each will result in its default value.

        ErikAIPath.maxSpeed = MaxSpeed;
        ErikAIPath.canMove = CanMove;
    }

    private void Chase()
    {
        SetErikSpeed(3);
    }

    private void Idle()
    {
        SetErikSpeed(0);
    }

    private void Patrol()
    {
        SetErikSpeed(1.5f);
    }

    private void Lurk()
    {
        SetErikSpeed(0.5f);
    }

    private void Flee()
    {
        SetErikSpeed(5.0f);
        ErikLocalTargetObj.transform.position = lastAnchor;
        AngerValue += 1.0f;
    }
}

