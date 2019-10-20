using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerCrabtopus : MonoBehaviour
{
    public float speed = 3f;
    public int health = 30;
    public float acidSpeed = 1000f;
    public GameObject acidPrefab;

    bool dead = false;
    float time;
    Rigidbody2D rigidbody2d;
    Vector2 position;
    Vector2 right;
    CapsuleCollider2D collision;
   
    //Animator animator;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        collision = GetComponent<CapsuleCollider2D>();

        time = Time.time;
        right = new Vector2(1, 0);
    }

    public void Damage(float despawnTime)
    {
        --health;
        if (health <= 0)
        {
            dead = true;
            //animator.SetTrigger("Dead");
            rigidbody2d.gravityScale = 0;
            Destroy(collision);
            Destroy(gameObject, despawnTime);
        }
    }

    void Update()
    {
        if (!dead)
        {
            if (Time.time - time > 1)
            {
                Shoot();
                time = Time.time;
            }
            move();
        }
    }

    void move()
    {
        Vector2 position = rigidbody2d.position;

        if (Time.time % 2 > 0 && Time.time % 2 < 1)
            position += right * speed * Time.deltaTime;
        else
            position += -1 * right * speed * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        CharacterMovement2_5b sonny = other.gameObject.GetComponent<CharacterMovement2_5b>();
        if (sonny != null)
        {
            sonny.ChangeHealth(-1);
        }
    }

    void Shoot()
    {
        Vector2 attack = new Vector2(-1, -.3f);
        GameObject acidObject = Instantiate(acidPrefab, rigidbody2d.position, Quaternion.identity);
        Acid acid = acidObject.GetComponent<Acid>();
        acid.Shoot(attack, acidSpeed);
    }
}
