using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float despawnTime = .1f;
    public float bulletSpeed = 3000;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Projectile Collision with: " + other.gameObject);

        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Damage(despawnTime);
        }

        Destroy(gameObject, despawnTime);
    }

    void Update()
    {
        if (transform.position.magnitude > 1000f)
        {
            Destroy(gameObject);
        }
    }
}
