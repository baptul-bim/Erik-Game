using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHearts = 3;

    public int heartsLeft = 3;
    float timer;
    public bool stunned;
    GameObject _Erikmanager;
    
    // Start is called before the first frame update
    void Start()
    {
        _Erikmanager = GameObject.FindGameObjectWithTag("ErikManager");
    }
    private int prevHearts = 3;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (prevHearts > heartsLeft)
        {
            stunned = true;
            prevHearts = heartsLeft;
        }

        if (stunned)
        {
            if (timer > 2.5f)
            {
                timer = 0;
            }
            else if (timer >= 2)
            {
                stunned = false;
            }
        }
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
