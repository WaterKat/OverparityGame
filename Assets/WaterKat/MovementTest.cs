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

        if (Input.GetKey("d"))
        {
            InputX = 1;
        }
        else
        {
            if (Input.GetKey("a"))
            {
                InputX = -1;
            }
            else
            {
                InputX = 0;
            }
        }


          GetComponent<SpriteRenderer>().flipX = (InputX < 0);

        

        //InputY = Input.GetAxis("0Joystick_LSY");
		
		Vector3 currentVelocity = rigidBody.velocity;
		currentVelocity.x = InputX*Speed;

        if (Input.GetKey("w"))
        {
            currentVelocity.y = Speed;
        }

        rigidBody.velocity = currentVelocity;
    }
}
