using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedRevives : MonoBehaviour
{
    public int HEALTH = 3;
    
    private int health;
    Rigidbody2D rb;
    BlindBoss bb;
    float deathTime = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bb = GetComponent<BlindBoss>();
        health = HEALTH;
    }

    void Update()
    {
        if (bb.triggered == false && !Mathf.Approximately(deathTime, 0f))
        {
            if (Time.time - deathTime > 5f)
            {
                health = HEALTH;
                bb.triggered = true;
            }
        }
    }

    public void Damage(float despawnTime)
    {
        --health;
        if (health <= 0)
        {
            bb.triggered = false;
            deathTime = Time.time;
            //animator.SetTrigger("Dead");
        }
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
    }
}
