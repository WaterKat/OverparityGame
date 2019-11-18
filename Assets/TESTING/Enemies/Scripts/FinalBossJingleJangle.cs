using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossJingleJangle : MonoBehaviour
{
    public FinalBoss fb;
    Rigidbody2D rb;

    void Start()
    {
        rb = fb.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject thing = other.gameObject;
        if (thing.tag == "Player")
        {
            fb.triggered = true;
            ++fb.numTriggers;
            if (fb.numTriggers == 1)
                rb.position = rb.position + new Vector2(0, 20);
            else if(fb.numTriggers == 2)
                rb.position = rb.position + new Vector2(0, -30);
        }
        Destroy(gameObject);
        Debug.Log(fb.numTriggers);
    }
}
