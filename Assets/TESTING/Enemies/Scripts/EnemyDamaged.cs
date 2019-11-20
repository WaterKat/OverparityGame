using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public int HEALTH = 3;
    private int health;

    public string DamageSound = "TardigradeSqueal";

    Rigidbody2D rb;
    bool dead = false;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = HEALTH;
        anim = GetComponent<Animator>();
    }

    public void Damage(float despawnTime)
    {
        WaterKat.Audio.AudioManager.PlaySound(DamageSound);

        --health;
        if (health <= 0)
        {
            dead = true;

            //animator.SetTrigger("Dead");
            rb.gravityScale = 0;
            anim.SetTrigger("isDying");
            Destroy(rb);
            Destroy(gameObject, despawnTime);
        }
        else
            anim.SetTrigger("isDamaged");
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
    }
}
