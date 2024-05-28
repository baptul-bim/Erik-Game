using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;
using Pathfinding.Util;
public class ErikManager : MonoBehaviour
{
    //louie temp bool
    public bool _hasHit = false;

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

    public delegate void ErikSeesPlayerDelegate();
    public delegate void ChooseNewTargetPosition();

    public static event ErikSeesPlayerDelegate erikSeeCallback;
    public static event ChooseNewTargetPosition erikEndPath;

    AIDestinationPicker erikDestPicker;

    [SerializeField] private ErikAudioManager ErikAudioMan;

    public Vector3 previousStepPos = Vector3.zero;
    public Vector3 currentStepPos;

    // Start is called before the first frame update
    void Start()
    {
        erikSeeCallback += delegateErikSeesPlayer;
        erikEndPath += delegateErikEndPath;

        ErikDestinationSetter = ErikObj.GetComponent<AIDestinationSetter>();
        ErikAIPath = ErikObj.GetComponent<AIPath>();

        erikCollider = ErikObj.GetComponentInChildren<Collider>();
        playerObj = GameObject.FindGameObjectWithTag("Player"); //Change so that playerObj changes to sixtens player
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

        ErikAudioMan = ErikObj.GetComponentInChildren<ErikAudioManager>();

        erikDestPicker = gameObject.GetComponent<AIDestinationPicker>();
    }

    // Update is called once per frame
    void Update()
    {
        erikStep();
        PlayerInSight = erikSeePlayer();
        ErikInSight = playerSeesErik();
        
        if (ErikAIPath.reachedEndOfPath)
        {
            erikEndPath(); //Erik reach end of path. A random point to walk towards.
                           //While observed it may look like a bug that erik can choose a lot of points in a short time frame,
                           //it actually works as intended and also fixes a bug where he would choose the same point he arrived to and then never walk again.

            
        }

        if (ErikVisabilityProcent >= 1.0f)
        {
            print(ErikVisabilityProcent);
        }
        
        if (PlayerInSight)
        {
            if (timeSinceSeenPlayer > 1.0f)
            {
                erikSeeCallback(); //Erik see u
            }
            timeSinceSeenPlayer = 0.0f;
        }
        else
        {
            timeSinceSeenPlayer += 1.0f * Time.deltaTime;
        }

        if (ErikCurrentState == "Flee")
        {
            //ErikObj.transform.GetChild(0).transform.LookAt(ErikObj.transform.position -ErikObj.transform.forward); //Erik looks the oppisite way of where he is running
            ErikObj.transform.GetChild(0).transform.LookAt(playerObj.transform); //Erik looks at the player while he is running away


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

      
        if (ErikInSight)
        {

            float normalCamOffset = 0.85f;
            float distanceFromNormalPlayerCam = Vector3.Distance(playerCam.transform.position, ErikObj.transform.position) - normalCamOffset;
            float cameraOffsetCenter = Vector3.Distance(playerCam.transform.position + playerCam.transform.forward, ErikObj.transform.position);

            //-print("NORMAL: " + distanceFromNormalPlayerCam + ", OFFSET: " + cameraOffsetCenter);
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
                if (ErikCurrentState == "Flee") //Teleports erik to a decided position when fleeing out of player's vision, this position is supposed to be far away from the player.
                {
                    erikDestPicker.w_list.Sort((a,b) => a.Weight.CompareTo(b.Weight));
                    //print("Distance between player and highest weight" + Vector3.Distance(playerObj.transform.position, erikDestPicker.w_list[erikDestPicker.w_list.Count - 1].Item.transform.position));
                    relocateErik(erikDestPicker.w_list[erikDestPicker.w_list.Count - 1].Item.transform.position); //For some reason the item with most weight is the item farthest away from the player.

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
        print("trying to set target to " + TargetPointObj);
        if (ErikDestinationSetter != null && ErikDestinationSetter.target != ErikLocalTargetObj.transform && ErikCurrentState != "Chase")
        {
            ErikDestinationSetter.target = ErikLocalTargetObj.transform;
        }

        ErikLocalTargetObj.transform.position = TargetPointObj.transform.position;

        print("set target to " + TargetPointObj);


    }

    private void delegateErikEndPath()
    {
        if (ErikCurrentState == "Chase" && Vector3.Distance(ErikObj.transform.position, playerObj.transform.position) < 2.5f) //2.5f is an arbitrary number. This "sort of" fixes a bug where erik can hit you while not actually being near you.
        {
            erikhitPlayer();
        }
        
        print("erik reached end of path");

    }
    private void delegateErikSeesPlayer()
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
        ErikObj.transform.position = NewErikPosition; //test
        print("distance between new point and player " + Vector3.Distance(playerObj.transform.position, NewErikPosition));
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

    private void erikhitPlayer()
    {
        print("erik hit the player");

        //Do damage against player here
        if (_hasHit != true)
        {
            playerObj.GetComponent<PlayerHealthManager>().TakeDamage();
            _hasHit = true;
        }
        



        relocateErik(erikDestPicker.w_list.RandomItem().transform.position);
        _hasHit =false;

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

    public Material ErikOnMaterial()
    {
        RaycastHit hit;
        if (Physics.Raycast(ErikObj.transform.position, Vector3.down, out hit) && hit.collider.tag == "WhatIsGround")
        {
            return hit.collider.GetComponent<Material>();
        }
        else
        {
            return null;
        }

    }

    private void erikStep()
    {
        currentStepPos = ErikObj.transform.position;

        if (Vector3.Distance(currentStepPos, previousStepPos) > 0.5f)
        {
            ErikAudioMan.PlayRandomErikStep();
            previousStepPos = currentStepPos;
        }
    }
    

    
}

