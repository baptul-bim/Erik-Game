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

    void start_task()
    {
        rapport.facit = true;
        facitObj.SetActive(false);
    }
}
