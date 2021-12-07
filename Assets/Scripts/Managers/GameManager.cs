using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject respawnBox, player1, player2, fadeController, cheerTrigger; 
    public float player1Points, player2Points;
    public float startGametimer = 1f;
    public float fallTimer = 1f;
    public float launchPower;
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

    public TextMeshProUGUI mathQuestion, answerChoice1, answerChoice2;

    //Add arrow to indicate turn
    public GameObject p1arrow;
    public GameObject p2arrow;

    [Header("Math Vars")]
    [SerializeField]
    private GameMath gameMath;
    private Player2 player2Component;
    private Player1 player1Component;
    private string answer = "";
    private bool needPlayerTurnIndicator = false;

    //Handling setting-up the game instance here first and foremost
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player1Component = player1?.GetComponent<Player1>();
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player2Component = player2?.GetComponent<Player2>();
        //math = gameObject.GetComponent<Math>();
        fadeController?.GetComponent<Animator>().SetBool("canFadeIn", true);
        StartCoroutine(GameStart());
        player1Points = 0f;
        player2Points = 0f;
        player1Turn = true;
        needPlayerTurnIndicator = true;
        Debug.Log(player1Points);
    }

     public bool isGameScene()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameScene())
        {
            player1PointsDisplay.text = player1Points.ToString();
            player2PointsDisplay.text = player2Points.ToString();
        }




        if (player1Wins)
        {
            //win state for player 1 
        }

        if (player2Wins)
        {
            //win state for player 2
        }


        if (inRound && isGameScene())
        {
            gameMath.Main();
            mathQuestion.text = gameMath.myEquation;
            answerChoice1.text = gameMath.myanswerChoice1;
            answerChoice2.text = gameMath.myanswerChoice2;
            answer = gameMath.correctAnswer;
            inRound = false;
            isChoosing = true;
            
        }

        if (isChoosing)
        {
            //Debug.Log("choosing");

            if (player1Turn)
            {
                //turn on arrow
                if (needPlayerTurnIndicator)

                {
                    p1arrow.GetComponentInChildren<MeshRenderer>().enabled = true;
                    p2arrow.GetComponentInChildren<MeshRenderer>().enabled = false;
                    needPlayerTurnIndicator = false;
                    Debug.Log("Turned on P1 Arrow, off P2 arrow");
                }
                
                //Handle input
                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    player1Component.player1Choice = answerChoice1.text;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player1Component.player1Choice = answerChoice2.text;
                }

                if (player1Component
                    && !string.IsNullOrEmpty(player1Component.player1Choice))
                {
                    if(player1Component.player1Choice == answer)
                    {
                        //Player 1 wins
                        player2.GetComponent<Rigidbody>().AddForce(
                            new Vector3(0f,0f,-launchPower), ForceMode.Impulse);
                        print("Player1 win");
                        //Add points to Player 1
                        player1Points = player1Points + 10f;
                        //Handle moving to the next turn
                        StartCoroutine("ResetGameState");
                    }
                    else
                    {
                        //player1 loses 
                        player1.GetComponent<Rigidbody>().AddForce(
                            new Vector3(0f,0f,launchPower), ForceMode.Impulse);
                        print("Player1 loses");
                        //Add points to Player 2
                        player1Points = player1Points - 5f;
                        //Handle moving to the next turn
                        StartCoroutine("ResetGameState");
                    }

                }
            }
            else if (player2Turn)
            {
                Debug.Log("Waiting at player 2 turn...");
                //turn on arrow
                if (needPlayerTurnIndicator)

                {
                    p1arrow.GetComponentInChildren<MeshRenderer>().enabled = false;
                    p2arrow.GetComponentInChildren<MeshRenderer>().enabled = true;
                    needPlayerTurnIndicator = false;
                    Debug.Log("REVERSEEEEEEEE: Turned on P2 Arrow, off P1 arrow");
                }

                //Handle input
                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    player2Component.player2Choice = answerChoice1.text;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player2Component.player2Choice = answerChoice2.text;
                }

                if (player2Component
                    && !string.IsNullOrEmpty(player2Component.player2Choice))
                {
                    if (player2Component.player2Choice == answer)
                    {
                        //Player 2 Wins
                        player1.GetComponent<Rigidbody>().AddForce(
                            new Vector3(0f, 0f, launchPower), ForceMode.Impulse);
                        print("Player2 win");
                        //Add points to Player 2
                        player2Points = player2Points + 10f;
                        //Handle moving to the next turn
                        StartCoroutine("ResetGameState");
                    }
                    else
                    {
                        //player2 loses 
                        player2.GetComponent<Rigidbody>().AddForce(
                            new Vector3(0f, 0f, -launchPower), ForceMode.Impulse);
                        print("Player2 loses");
                        //Remove points to Player 2
                        player2Points = player2Points - 5f;
                        //Handle moving to the next turn
                        StartCoroutine("ResetGameState");
                    }

                }
            }
      
        }


        //Restart the level
        if(Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }

        //Exit the game.
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    private void startGame()
    {
        
        player1.GetComponent<Animator>()?.SetBool("canPull", true);
        player2.GetComponent<Animator>()?.SetBool("canPull", true);
        Debug.Log("rope pulling anim");
    }

    IEnumerator ResetGameState()
    {
        isChoosing = false;
        inRound = true;
        Debug.Log("PLAYER 1 TURN PRE: " + player1Turn);
        player1Turn = !player1Turn;
        Debug.Log("PLAYER 1 TURN POST: " + player1Turn);
        Debug.Log("PLAYER 2 TURN PRE: " + player2Turn);
        player2Turn = !player2Turn;
        Debug.Log("PLAYER 2 TURN PRE: " + player2Turn);
        //set answers back to null
        player1Component.player1Choice = null;
        player2Component.player2Choice = null;
        //Reset text
        needPlayerTurnIndicator = true;
        yield return null;
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

    IEnumerator FallTimer()
    {
        while (fallTimer > 0)
        {
            yield return new WaitForSeconds(fallTimer);
            fallTimer--;
        }
        fallTimer = 0;
        isChoosing = false;
    }
}