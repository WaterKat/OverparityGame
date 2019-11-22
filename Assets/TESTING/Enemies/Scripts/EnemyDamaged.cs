using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public int HEALTH = 3;
    private int health;

    public bool DestroyOnDeath = true;

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

        if (health > 0)
        {
            --health;
            HEALTH = health;
            anim.SetTrigger("isDamaged");
        }
        if (health <= 0)
        {
            dead = true;

            //animator.SetTrigger("Dead");
            if (rb != null)
            {
                rb.gravityScale = 0;
                Destroy(rb);
            }
            anim.SetTrigger("isDying");
            if (DestroyOnDeath)
            {
                Destroy(gameObject, despawnTime);
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
    }
}
