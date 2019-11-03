using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerCrabtopus : MonoBehaviour
{
    public float speed = 3f;
    public float acidSpeed = 10f;
    public GameObject acidPrefab;
    public GameObject player;
    public bool triggered = false;

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

    void Update()
    {
        if (!dead && player != null)
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

    void Shoot()
    {
        Vector2 attack = (Vector2)(player.transform.position - transform.position);

        GameObject acidObject = Instantiate(acidPrefab, rigidbody2d.position, Quaternion.identity);
        Acid acid = acidObject.GetComponent<Acid>();
        acid.Shoot(attack, acidSpeed);
    }
}