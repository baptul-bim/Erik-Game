using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeDebug : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerMove move;

    // Start is called before the first frame update
    void Start()
    {
        move = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = move.GetSlopeMoveDirection(move.moveDirection);
    }
}
