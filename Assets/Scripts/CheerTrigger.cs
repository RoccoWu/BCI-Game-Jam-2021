using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheerTrigger : MonoBehaviour
{
    public GameObject player1, player2;
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
