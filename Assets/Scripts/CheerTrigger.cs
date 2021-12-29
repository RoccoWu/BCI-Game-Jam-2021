using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheerTrigger : MonoBehaviour
{
    public GameObject player1, player2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            player2.GetComponent<Animator>().SetTrigger("wonRound");
            StartCoroutine(restartCountdown());
        }

        else if(other.CompareTag("Player2"))
        {           
            player1.GetComponent<Animator>().SetTrigger("wonRound");
             StartCoroutine(restartCountdown());
        }
    }

    private IEnumerator restartCountdown()
    {
        while(true)
        {
            yield return new WaitForSeconds(5); //wait for 3 seconds
            SceneManager.LoadScene("Game");
        }
    }
}
