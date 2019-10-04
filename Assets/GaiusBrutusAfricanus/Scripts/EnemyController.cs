using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 100f;
    public float patrolTime = 4;
    public int health = 3;

    bool dead = false;
    Rigidbody2D rigidbody2d;
    Vector2 position;
    Vector2 right;
    CapsuleCollider2D collision;
    Animator animator;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collision = GetComponent<CapsuleCollider2D>();

        right = new Vector2(1, 0);
    }

    public void Damage(float despawnTime)
    {
        --health;
        if (health <= 0)
        {
            dead = true;
            animator.SetTrigger("Dead");
            rigidbody2d.gravityScale = 0;
            Destroy(collision);
            Destroy(gameObject, despawnTime);
        }
    }

    void Update()
    {
        if (!dead)
        {
            Vector2 position = rigidbody2d.position;

            if (Time.time % patrolTime > 0 && Time.time % patrolTime < 1)
                position += right * speed * Time.deltaTime;
            else
                position += -1 * right * speed * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        SonnyController sonny = other.gameObject.GetComponent<SonnyController>();
        if(sonny !=null)
        {
            sonny.ChangeHealth(-1);
        }
    }
}
