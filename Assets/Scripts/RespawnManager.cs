using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Transform player1, player2, ball;
    public Transform p1Respawn, p2Respawn, ballRespawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            player1.position = p1Respawn.position; 
            print("respawn");
        }

        else if (other.tag == "Player2")
        {
            player2.position = p2Respawn.position; 
            print("respawn");
        }

        else if (other.tag == "Ball")
        {
            ball.position = ballRespawn.position; 
            print("respawn");
        }
    }
}
