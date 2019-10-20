using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    public float despawnTime = .1f;

    Rigidbody2D rigidbody2d;

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
        CharacterMovement2_5b sonny = other.collider.GetComponent<CharacterMovement2_5b>();
        if (sonny != null)
        {
            sonny.ChangeHealth(-1);
        }

        Destroy(gameObject, despawnTime);
    }

    void Update()
    {
        if (transform.position.magnitude > 100f)
        {
            Destroy(gameObject);
        }
    }
}
