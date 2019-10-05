using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class CharacterMovement2_5 : MonoBehaviour
{
    public float HorizontalSpeed = 7.5f;
    public float VerticalSpeed = 5f;

    Collider2D playerCollider;
    Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        float H_Input = Input.GetAxis("Horizontal");
        float V_Input = Input.GetAxis("Vertical");

        playerRigidbody.velocity = new Vector2(H_Input * HorizontalSpeed, V_Input * VerticalSpeed);

    }
}
