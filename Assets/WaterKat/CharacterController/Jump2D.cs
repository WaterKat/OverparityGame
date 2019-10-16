using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterKat.MathW;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump2D : MonoBehaviour
{
    public float JumpHeight;
    public float JumpTime;

    private float Gravity;

    Rigidbody2D playerRigidbody;

    void SetupGravityScale()
    {
        Gravity = (JumpHeight * 2) / Mathf.Sqrt(JumpTime);
    }

    void Jump()
    {
        playerRigidbody.velocity = MathW.SetVector(playerRigidbody.velocity, 1, JumpHeight / JumpTime);
    }

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        SetupGravityScale();
    }

    // Update is called once per frame
    void Update()
    {
        playerRigidbody.velocity = MathW.SetVector(playerRigidbody.velocity, 1, playerRigidbody.velocity.y + (Time.deltaTime * Gravity * -1f));
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }   
    }
}
