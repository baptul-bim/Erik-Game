using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Pathfinding.Util;
public class ErikManager : MonoBehaviour
{
    public GameObject ErikObj;
    [SerializeField] private AIDestinationSetter ErikDestinationSetter;
    [SerializeField] private AIPath ErikAIPath;
    public string ErikCurrentState;


    private Collider erikCollider;
    private Camera playerCam;
    private GameObject playerObj;
    private Plane[] cameraFrustum;

    private string[] avalibleStates = { "Chase", "Lurk", "Patrol", "Idle", "Flee" };
    private string previousState;
    [SerializeField] private bool PlayerInSight;
    [SerializeField] private bool ErikInSight;
    private float timeSinceSeenPlayer;

    [SerializeField] private float MaxChaseTime;
    [SerializeField] private float MaxLurkViewDistance;

    [SerializeField] private float AngerValue;
    //private List<Action> AvalibleStates;

    [SerializeField] private GameObject ErikLocalTargetObj;
    private Vector3 lastAnchor;
    private Vector3 previousDestination;

    [SerializeField] private float ErikVisabilityProcent;
    private float leastVisabilityValue;

    delegate void ErikSeesPlayerDelegate();
    delegate void ChooseNewTargetPosition();

    ErikSeesPlayerDelegate erikSeeCallback = delegateErikSeesPlayer;
    ChooseNewTargetPosition erikEndPath = delegateErikEndPath;
    private float timeSinceEndOfPath;
    
    // Start is called before the first frame update
    void Start()
    {
        
        ErikDestinationSetter = ErikObj.GetComponent<AIDestinationSetter>();
        ErikAIPath = ErikObj.GetComponent<AIPath>();

        erikCollider = ErikObj.GetComponentInChildren<Collider>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerCam = Camera.main;

        lastAnchor = ErikObj.transform.position;
        previousDestination = ErikAIPath.autoRepath.lastDestination;
        SetErikState("Patrol");

        MaxChaseTime = 10.0f;
        MaxLurkViewDistance = 10.0f;

        if (ErikLocalTargetObj == null)
        {
            ErikLocalTargetObj = Instantiate<GameObject>(GameObject.CreatePrimitive(PrimitiveType.Sphere));
            ErikLocalTargetObj.name = "LocalErikTarget";
        }

    }

    // Update is called once per frame
    void Update()
    {

        PlayerInSight = erikSeePlayer();
        ErikInSight = playerSeesErik();
        
        if (ErikAIPath.reachedEndOfPath)
        {
            if (timeSinceEndOfPath > 1.0f)
            {
                delegateErikEndPath();
            }
            timeSinceEndOfPath = 0.0f;
        }
        else
        {
            timeSinceEndOfPath += 1.0f * Time.deltaTime;
        }

        if (ErikVisabilityProcent >= 1.0f)
        {
            print(ErikVisabilityProcent);
        }
        
        if (PlayerInSight)
        {
            if (timeSinceSeenPlayer > 1.0f)
            {
                delegateErikSeesPlayer();
            }
            timeSinceSeenPlayer = 0.0f;
        }
        else
        {
            timeSinceSeenPlayer += 1.0f * Time.deltaTime;

            
        }

        

        if (timeSinceSeenPlayer <= 0.0f && ErikCurrentState != "Lurk" && ErikCurrentState == "Patrol" && !ErikInSight)
        {
            SetErikState("Lurk");

        }
        else if (ErikCurrentState == "Lurk" && (timeSinceSeenPlayer > 5.0f || Vector3.Distance(ErikObj.transform.position, playerObj.transform.position) > MaxLurkViewDistance || ErikInSight))
        {
            print("stopped lurking");
            SetErikState("Patrol");
        }
        


        if (ErikCurrentState == "Chase" && timeSinceSeenPlayer > MaxChaseTime) //De-aggros Erik after having chased the player for a certian time without seeing them.
        {
            SetErikState("Patrol");
            print("Stopped chasing");
        }

        /*
        if (int.TryParse(Input.inputString, out int numberPressed)) //Debug tool: Changes Erik's speed to the corresponding numeric key pressed.
        {
            SetErikSpeed(numberPressed);
        }*/

        if (ErikInSight)
        {

            //print(Vector3.Distance(playerCam.transform.position + playerCam.transform.forward, ErikObj.transform.position) + " and " + (Vector3.Distance(playerCam.transform.position, ErikObj.transform.position) - 0.75f));
            float normalCamOffset = 0.85f;
            float distanceFromNormalPlayerCam = Vector3.Distance(playerCam.transform.position, ErikObj.transform.position) - normalCamOffset;
            float cameraOffsetCenter = Vector3.Distance(playerCam.transform.position + playerCam.transform.forward, ErikObj.transform.position);

            print("NORMAL: " + distanceFromNormalPlayerCam + ", OFFSET: " + cameraOffsetCenter);
            if (leastVisabilityValue <= 0.0f)
            {
                leastVisabilityValue = distanceFromNormalPlayerCam / cameraOffsetCenter;
            }

            ErikVisabilityProcent = ((distanceFromNormalPlayerCam / cameraOffsetCenter) - leastVisabilityValue) / (1 - leastVisabilityValue);

            //The true visability value is (distanceFromNormalPlayerCam / cameraOffsetCenter).

           

            if (cameraOffsetCenter < distanceFromNormalPlayerCam) //|| Vector3.Distance(playerCam.transform.position, ErikObj.transform.position) < 1.0f)
            {

                if (distanceFromNormalPlayerCam > 1.5f && AngerValue <= 3.0f)
                {
                    //print(ErikVisabilityProcent);
                    SetErikState("Flee");
                }
                else 
                {
                    SetErikState("Chase");

                }
            }
            else if (ErikCurrentState != "Flee" && ErikCurrentState != "Chase") //Stuff that happens when erik is within egde border of player screen
            {

                SetErikState("Idle");
                print("Erik looks at you.");
                ErikObj.transform.LookAt(playerCam.transform);
            }

        }
        else 
        {
            ErikVisabilityProcent = 0.0f;
            leastVisabilityValue = 0.0f;
            if (ErikCurrentState == "Patrol" && previousDestination != ErikAIPath.autoRepath.lastDestination) //Places a new anchor position to run back to later if erik needs to flee.
                                                                                                             //This anchor is placed everytime erik gets a new destination to follow.
            {
                lastAnchor = ErikObj.transform.position;
                previousDestination = ErikAIPath.autoRepath.lastDestination;
                print("placed new anchor");
            }
            else if (ErikCurrentState != "Patrol" && AngerValue <= 3.0f)
            {
                if (ErikCurrentState == "Flee") //Teleports erik to a decided position when fleeing out of player's vision
                {
                    relocateErik(lastAnchor); //Replace lastAnchor with a decent point to teleport to.
                }
                else if (ErikCurrentState == "Idle") //Makes Erik continue his previous behaviour if player did not trigger a flee in erik and then looked away from him.
                {
                    SetErikState(previousState);
                    print("erik continues " + previousState);
                }
            }



        }

        
       
    }

   



    /// <summary>
    /// Changes the current state of the Erik AI.
    /// <list type="States">
    /// Avalible States:
    /// <item>Chase, Idle, Patrol, Lurk, Flee</item>
    /// </list>
    /// </summary>
    /// <param name="State"></param>
    public void SetErikState(string stateName)
    {
        if (ErikCurrentState != stateName)
        {
            foreach (string state in avalibleStates)
            {
                if (state == stateName)
                {
                    previousState = ErikCurrentState;
                    Invoke(stateName, 0.0f);
                    ErikCurrentState = stateName;
                }
            }
        }
        
        

    }

    public void SetErikTarget(GameObject TargetPointObj)
    {
        if (ErikDestinationSetter.target != ErikLocalTargetObj.transform && ErikCurrentState != "Chase")
        {
            ErikDestinationSetter.target = ErikLocalTargetObj.transform;
        }
        ErikLocalTargetObj.transform.position = TargetPointObj.transform.position;
        
    }

    private static void delegateErikEndPath()
    {
        print("erik reached end of path");
    }
    private static void delegateErikSeesPlayer()
    {
        print("erik saw player");
    }

    private bool playerSeesErik()
    {
        Bounds erikColliderBounds = erikCollider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(playerCam);

        RaycastHit hit;
        Physics.Raycast(playerCam.transform.position, (ErikObj.transform.position - playerCam.transform.position).normalized, out hit, Vector3.Distance(ErikObj.transform.position, playerCam.transform.position));


        if (GeometryUtility.TestPlanesAABB(cameraFrustum, erikColliderBounds) && (hit.collider == null || hit.collider != null && hit.collider.gameObject.tag == "Player"))
        {
            //print("Can see erik"); --
            return true;

        }
        else
        {
            //print("Cannot see erik");  --
            return false;
        }

    }

    public void SetErikSpeed(float MaxSpeed = 1, bool CanMove = true) 
    {
        //If method is called without specifying parameters, each will result in its default value.

        ErikAIPath.maxSpeed = MaxSpeed;
        ErikAIPath.canMove = CanMove;
    }

    private void relocateErik(Vector3 NewErikPosition)
    {
        ErikLocalTargetObj.transform.position = previousDestination;
        ErikObj.transform.position = NewErikPosition; //test
        SetErikState("Patrol");
        print("Relocated erik");
    }

    private bool erikSeePlayer()
    {
        RaycastHit hit;
        Physics.Raycast(playerCam.transform.position, (ErikObj.transform.position - playerCam.transform.position).normalized, out hit, Vector3.Distance(ErikObj.transform.position, playerCam.transform.position));
        if (hit.collider == null || hit.collider != null && hit.collider.gameObject.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Chase()
    {
        ErikDestinationSetter.target = playerObj.transform;
        SetErikSpeed(3);

        print("started chasing");
    }

    private void Idle()
    {
        SetErikSpeed(0);
    }

    private void Patrol()
    {
        if (ErikDestinationSetter.target != ErikLocalTargetObj.transform)
        {
            ErikDestinationSetter.target = ErikLocalTargetObj.transform;
        }
        SetErikSpeed(1.5f);
        print("Started patrolling");
    }

    private void Lurk()
    {
        SetErikSpeed(0.5f);
        ErikDestinationSetter.target = playerObj.transform;
        print("Started lurking");
    }

    private void Flee()
    {
        SetErikSpeed(5.0f);
        ErikLocalTargetObj.transform.position = lastAnchor;
        AngerValue += 1.0f;
        print("Started fleeing");
    }

    
}

