using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpit : MonoBehaviour
{
    Rigidbody2D spitRB;
    public float velocity = 5;
    // Start is called before the first frame update
    void Start()
    {
        spitRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
         spitRB.velocity = (player.transform.position-transform.position).normalized*velocity;
            if (transform.position.x > player.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan((player.transform.position.y - transform.position.y) / (player.transform.position.x - transform.position.x)));
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0,180+  Mathf.Rad2Deg * Mathf.Atan((player.transform.position.y - transform.position.y) / (player.transform.position.x - transform.position.x)));

            }
        }
    }
}
