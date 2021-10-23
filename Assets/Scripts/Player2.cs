using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
     public int speed;

    [SerializeField]
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //when player 2 presses [button] add negative force to Z axis
        if(Input.GetKey(KeyCode.RightShift))
        {
            rb.AddForce(new Vector3(0f,0f,speed *-1));
        }
    }
    
}
