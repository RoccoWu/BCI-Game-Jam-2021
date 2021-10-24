using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject respawnBox, player1, player2;
    public float player1Points, player2Points;
    public float startGametimer = 1f;
    public bool gameStart = false;
    public TextMeshProUGUI player1PointsDisplay, player2PointsDisplay;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        StartCoroutine(GameStart());
        player1Points = 0f;
        player2Points = 0f;
        Debug.Log(player1Points);
    }

    // Update is called once per frame
    void Update()
    {
        player1PointsDisplay.text = player1Points.ToString();
        player2PointsDisplay.text = player2Points.ToString();
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