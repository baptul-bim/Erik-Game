using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHearts = 3;
    
    public int heartsLeft = 3;

    GameObject _Erikmanager;
    // Start is called before the first frame update
    void Start()
    {
        _Erikmanager = GameObject.FindGameObjectWithTag("ErikManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage()
    {
        heartsLeft--;
        if (heartsLeft <= 0)
        {
            
            _Erikmanager.GetComponent<ErikAnimationManager>().PlayJumpscare();
        }
    }

    
}
