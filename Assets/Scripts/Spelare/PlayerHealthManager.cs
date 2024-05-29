using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHearts = 3;
<<<<<<< HEAD
    public int heartsLeft = 0;

    GameObject _Erikmanager;
=======
    public int heartsLeft = 3;
>>>>>>> parent of 68a9d72 (Revert "Merge remote-tracking branch 'upstream/main' into ErikGrupp")

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        _Erikmanager = GameObject.FindGameObjectWithTag("ErikManager");
=======
        
>>>>>>> parent of 68a9d72 (Revert "Merge remote-tracking branch 'upstream/main' into ErikGrupp")
    }

    // Update is called once per frame
    void Update()
    {
        
    }

<<<<<<< HEAD

    public void TakeDamage()
    {
        print("tried to damage");

        heartsLeft--;
        if (heartsLeft <= 0)
        {
            FindObjectOfType<ErikAnimationManager>().PlayJumpscare();
        }
    }

=======
>>>>>>> parent of 68a9d72 (Revert "Merge remote-tracking branch 'upstream/main' into ErikGrupp")
    
}
