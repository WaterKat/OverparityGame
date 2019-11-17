using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoiraMove : MonoBehaviour
{
    public float horizontalSpeed = 5f;
    public float verticalSpeed = 5f;

    Rigidbody2D rigidbody2d;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2d.velocity = new Vector2(1,0);
        anim.SetFloat("Blend", rigidbody2d.velocity.x + rigidbody2d.velocity.y);
    }
}
