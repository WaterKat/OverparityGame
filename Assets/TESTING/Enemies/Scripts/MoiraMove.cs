using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoiraMove : MonoBehaviour
{
    public float horizontalSpeed = 5f;
    public float verticalSpeed = 5f;

    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
