using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private Player2 instance;
     public int speed;
     public string player2Choice = null;

    [SerializeField]
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (GameManager.instance.player2Turn == true)
    //        //if player one presses a , they select answerchoice 1

    //        if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))// || Input.GetKey(KeyCode.LeftArrow))
    //        {
    //            player2Choice = GameManager.instance.answerChoice1.text;
    //        }

    //        else if (Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2))// || Input.GetKey(KeyCode.RightArrow))
    //        {
    //            player2Choice = GameManager.instance.answerChoice2.text;
    //        }
    //}

    //void FixedUpdate()
    //{
    //    //when player 2 presses [button] add negative force to Z axis
    //    if(Input.GetKey(KeyCode.RightShift))
    //    {
    //        rb.AddForce(new Vector3(0f,0f,speed *-1));
    //    }

    //    else if(Input.GetKey(KeyCode.RightControl))
    //    {
    //        rb.AddForce(new Vector3(0f,0f,speed *1));
    //    }
    //}
    
}
