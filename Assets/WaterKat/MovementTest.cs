using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
	public Rigidbody2D rigidBody;
	
	public float Speed = 10;
	
	public float InputX;
	public float InputY;

	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //InputX = Input.GetAxis("0Joystick_LSX");
        if (Input.GetKey("d"))
        {
            InputX = 1;
        }else if (Input.GetKey("a"))
        {
            InputX = -1;
        }
        else
        {
            InputX = 0;
        }
        InputY = Input.GetAxis("0Joystick_LSY");
		
		Vector3 currentVelocity = rigidBody.velocity;
		currentVelocity.x = InputX*Speed;
        rigidBody.velocity = currentVelocity;
    }
}
