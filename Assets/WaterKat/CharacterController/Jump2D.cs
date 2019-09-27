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

    Rigidbody2D rigidbody;

    void SetupGravityScale()
    {
        Gravity = (JumpHeight * 2) / Mathf.Sqrt(JumpTime);
    }

    void Jump()
    {
        rigidbody.velocity = MathW.SetVector(rigidbody.velocity, 1, JumpHeight / JumpTime);
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        SetupGravityScale();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = MathW.SetVector(rigidbody.velocity, 1, rigidbody.velocity.y + (Time.deltaTime * Gravity * -1f));
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }   
    }
}
