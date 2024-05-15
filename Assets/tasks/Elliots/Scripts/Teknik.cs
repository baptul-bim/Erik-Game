using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teknik : MonoBehaviour
{
    private LineRenderer line;

    GameObject startObj;
    GameObject destinationObj;

    Vector3 offset;

    // Start is called before the first frame update
    private void Start()
    {
        line = GetComponent<LineRenderer>();
        startObj = GameObject.Find("A1");
        destinationObj = GameObject.Find("A2");
    }

   /* private void Update()
    {
        //Vector3 WorldMousePos = GetWorldPoint
        line.SetPosition(0, transform.position);
        line.SetPosition(1, WorldMousePos());


        //line.SetPosition(1, destinationObj.transform.position);
    }
   */
    
    private void OnMouseDown()
    {
        print("down");
        offset = transform.position - WorldMousePos();
    }
    private void OnMouseDrag()
    {
        print("drag: " +line.positionCount);
        //print();
        line.SetPosition(0, WorldMousePos() + offset);
        line.SetPosition(1, transform.position);

    }
    private void OnMouseUp()
    {
        print("up");
        Vector3 rayOrigin = Camera.main.transform.position;
        Vector3 rayDir = WorldMousePos() - Camera.main.transform.position;
        RaycastHit hitInfo;

        /*if (Physics.Raycast(rayOrigin, rayDir, out hitInfo) && hitInfo.transform.gameObject == destinationObj) 
        {
        
            
        
        
        }*/

        if (Physics.Raycast(rayOrigin, rayDir, out hitInfo))
        {

            if (hitInfo.transform.gameObject == destinationObj) 
            {
                print("connected");
                line.SetPosition(0, hitInfo.transform.position);
                transform.gameObject.GetComponent<Collider>().enabled = false;
            
            }
            else 
            {

                line.SetPosition(0, transform.position);
            }


        }


    }
    private Vector3 WorldMousePos() //translate mouse position from screen to world
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
