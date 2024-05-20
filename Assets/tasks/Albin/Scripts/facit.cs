using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facit : MonoBehaviour
{
    rapport rapport;
    [SerializeField]
    GameObject facitObj;
    // Start is called before the first frame update
    void Start()
    {
        rapport = FindObjectOfType<rapport>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            rapport.facit = true;
            facitObj.SetActive(false);
        }
    }
}
