using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Player1 instance;
    public int speed;
    public string player1Choice = null;

    [SerializeField]
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    //void Update()
    //{
    //  if(GameManager.instance.player1Turn == true)      
    //      //if player one presses a , they select answerchoice 1

    //      if(Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))// || Input.GetKey(KeyCode.LeftArrow))
    //      {
    //         player1Choice = GameManager.instance.answerChoice1.text; 
    //      }

    //      else if(Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2))// || Input.GetKey(KeyCode.RightArrow))
    //      {
    //         player1Choice = GameManager.instance.answerChoice2.text; 
    //      }    
    //}

    //void FixedUpdate()
    //{
    //    //when player 2 presses [button] add negative force to Z axis
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        rb.AddForce(new Vector3(0f, 0f, speed * 1));
    //    }

    //    else if (Input.GetKey(KeyCode.LeftControl))
    //    {
    //        rb.AddForce(new Vector3(0f, 0f, speed * -1));
    //    }

    //}
}
