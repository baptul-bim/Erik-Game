using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class ErikManager : MonoBehaviour
{
    [SerializeField] private GameObject ErikObj;
    [SerializeField] private AIDestinationSetter ErikDestinationSetter;
    [SerializeField] private AIPath ErikAIPath;
    [SerializeField] private string ErikCurrentState;

    private string[] avalibleStates = { "Chase", "Lurk", "Patrol", "Idle" };

    [SerializeField] private bool PlayerInSight;
    private float timeSinceSeenPlayer;

    [SerializeField] private float MaxChaseTime;


    //private List<Action> AvalibleStates;
    

    // Start is called before the first frame update
    void Start()
    {
        ErikDestinationSetter = ErikObj.GetComponent<AIDestinationSetter>();
        ErikAIPath = ErikObj.GetComponent<AIPath>();

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

    public void SetErikTarget(GameObject TargetObj)
    {
        ErikDestinationSetter.target = TargetObj.transform;
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

}

