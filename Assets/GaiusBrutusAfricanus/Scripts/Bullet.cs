using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float despawnTime = 2f;

    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction, float force)
    {
        direction *= new Vector2(1, .75f);
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController enemy = other.collider.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.Damage(despawnTime);
        }

        /*EnemyControllerCrabtopus cenemy = other.collider.GetComponent<EnemyControllerCrabtopus>();
        if (cenemy != null)
        {
            cenemy.Damage(despawnTime);
        }*/

        Destroy(gameObject, despawnTime/5);
    }

    void Update()
    {
        if (transform.position.magnitude > 300f)
        {
            Destroy(gameObject);
        }
    }
}
