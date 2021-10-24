using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{

    public static RespawnManager instance;
    public Transform player1, player2, ball;
    public Transform p1Respawn, p2Respawn, ballRespawn;
    private float respawnTimerP1 = 1.5f;
    private float respawnTimerP2 = 1.5f;
    public bool p1canRespawn = false;
    public bool p2canRespawn = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (p1canRespawn)
        {
            player1.position = p1Respawn.position;
            GameManager.instance.player2Points++;
            p1canRespawn = false;
            print("respawn");
        }

        if (p2canRespawn)
        {
            player2.position = p2Respawn.position;
            GameManager.instance.player1Points++;
            p2canRespawn = false;
            print("respawn");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            StartCoroutine(respawnDelayPlayer1());
        }

        else if (other.tag == "Player2")
        {
            StartCoroutine(respawnDelayPlayer2());
        }
    }

    IEnumerator respawnDelayPlayer1()
    {
        while (respawnTimerP1 > 0)
        {
            yield return new WaitForSeconds(respawnTimerP1);
            respawnTimerP1--;
        }
        respawnTimerP1 = 0;
        p1canRespawn = true;
    }

    IEnumerator respawnDelayPlayer2()
    {
        while (respawnTimerP2 > 0)
        {
            yield return new WaitForSeconds(respawnTimerP2);
            respawnTimerP2--;
        }
        respawnTimerP2 = 0;
        p2canRespawn = true;
    }
}
