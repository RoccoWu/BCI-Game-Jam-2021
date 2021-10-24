using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject respawnBox, player1, player2;
    public float player1Points, player2Points;
    public float startGametimer = 1f;
    public bool gameStart = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameStart());
    }

    // Update is called once per frame
    void Update()
    {
        //if players hit the respawn box, then respawn point
    }

    private void startGame()
    {
        player1.GetComponent<Animator>().SetBool("canPull", true);
        player2.GetComponent<Animator>().SetBool("canPull", true);
        Debug.Log("rope pulling anim");
    }
    IEnumerator GameStart()
    {
        while (startGametimer > 0)
        {
            yield return new WaitForSeconds(startGametimer);
            startGametimer--;
        }
        startGametimer = 0;
        Debug.Log("timer up");
        startGame();
    }

}


