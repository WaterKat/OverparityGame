using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public int HEALTH = 3;
    private int health;

    Rigidbody2D rb;
    bool dead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = HEALTH;
    }

    public void Damage(float despawnTime)
    {
        --health;
        if (health <= 0)
        {
            dead = true;
            //animator.SetTrigger("Dead");
            rb.gravityScale = 0;
            Destroy(rb);
            Destroy(gameObject, despawnTime);
        }
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
    }
}
