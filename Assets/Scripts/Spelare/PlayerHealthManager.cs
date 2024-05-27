using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHearts = 3;
    public int heartsLeft = 3;
    float timer;
    public bool stunned;

    // Start is called before the first frame update
    void Start()
    {
        
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
            timer = 0;
            if(timer >= 2)
            {
                stunned = false;
            }
        }
    }
}
