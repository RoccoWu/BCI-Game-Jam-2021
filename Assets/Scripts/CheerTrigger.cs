using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheerTrigger : MonoBehaviour
{
    public GameObject player1, player2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            player2.GetComponent<Animator>().SetTrigger("wonRound");
        }

        else if(other.CompareTag("Player2"))
        {           
            player1.GetComponent<Animator>().SetTrigger("wonRound");
        }
    }
}
