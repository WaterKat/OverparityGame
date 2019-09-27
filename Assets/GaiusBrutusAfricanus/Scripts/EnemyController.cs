using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private Vector2 position;
    private Vector2 right;
    public float speed = 3f;
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        right = new Vector2(1, 0);
    }

    public void Damage(float despawnTime)
    {
        --health;
        if (health <= 0)
            Destroy(gameObject, despawnTime);
    }

    void Kill(float despawnTime)
    {
        Destroy(gameObject, despawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rigidbody2d.position;

        if(Time.time % 2 > 0 && Time.time % 2 < 1)
            position += right * speed * Time.deltaTime;
        else
            position += -1 * right * speed * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
}
