using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ErikManager : MonoBehaviour
{
    [SerializeField] private GameObject ErikObj;
    [SerializeField] private AIDestinationSetter ErikDestinationSetter;
    [SerializeField] private AIPath ErikAIPath;
    // Start is called before the first frame update
    void Start()
    {
        ErikDestinationSetter = ErikObj.GetComponent<AIDestinationSetter>();
        ErikAIPath = ErikObj.GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetErikTarget(GameObject TargetObj)
    {
        ErikDestinationSetter.target = TargetObj.transform;
    }

    public void SetErikMaxSpeed(float MaxSpeed)
    {
        ErikAIPath.maxSpeed = MaxSpeed;
    }


}
