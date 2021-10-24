using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject respawnBox, player1, player2, fadeController, cheerTrigger;
    public float player1Points, player2Points;
    public float startGametimer = 1f;
    public bool gameStart = false;
    public bool inRound = false;
    public bool isChoosing = false;
    public TextMeshProUGUI player1PointsDisplay, player2PointsDisplay;
    public bool player1Wins = false;
    public bool player2Wins = false;

    public bool player1Correct = false;
    public bool player2Correct = false;
    public bool player1Turn = false;
    public bool player2Turn = false;
    
    [Header("Math Vars")]
    [SerializeField]
    private GameMath gameMath;
    public TextMeshProUGUI mathQuestion, answerChoice1, answerChoice2;
    private string answer = "";



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        //math = gameObject.GetComponent<Math>();
        fadeController?.GetComponent<Animator>().SetBool("canFadeIn", true);
        StartCoroutine(GameStart());
        player1Points = 0f;
        player2Points = 0f;
        player1Turn = true;
        Debug.Log(player1Points);
    }

    // Update is called once per frame
    void Update()
    {
        player1PointsDisplay.text = player1Points.ToString();
        player2PointsDisplay.text = player2Points.ToString();

        if(player1Wins)
        {
            //win state for player 1 
        }

        if(player2Wins)
        {
            //win state for player 2
        }


        if(inRound)
        {
            gameMath.Main();
            mathQuestion.text = gameMath.myEquation;
            answerChoice1.text = gameMath.myanswerChoice1;
            answerChoice2.text = gameMath.myanswerChoice2;
            answer = gameMath.correctAnswer; 
            inRound = false;
            isChoosing = true;
        }

        if(isChoosing)
        {
            if(player1Turn)
            {                
                if(player1?.GetComponent<Player1>().player1Choice == answer)
                {
                    //player1 win round
                }

                else if(player1?.GetComponent<Player1>().player1Choice != answer)
                {
                    //player2 loses 
                }
            }
            
        }
        

    }

    private void startGame()
    {
        player1.GetComponent<Animator>()?.SetBool("canPull", true);
        player2.GetComponent<Animator>()?.SetBool("canPull", true);
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
        inRound = true;
        Debug.Log("timer up");
        startGame();
    }

}