using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonnyController : MonoBehaviour
{
    public float speed = 5f;
    //public int maxHealth = 1;
    //int currentHealth;
    Rigidbody2D rigidbody2d;
    bool sneaking = false;

    //public int health { get { return currentHealth; } }

    //public float timeInvincible = .5f;
    //bool isInvincible;
    //float invincibleTimer;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    Vector2 JumpForce = new Vector2(0, 3000);

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        rigidbody2d = GetComponent<Rigidbody2D>();

        //currentHealth = maxHealth;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!sneaking)
            {
                speed = 2.5f;
                sneaking = true;
            }
            else
            {
                speed = 5f;
                sneaking = false;
            }
            //animator.SetTrigger("Sneak");
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 10f;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.AddForce(JumpForce);
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5f;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //Debug.Log(horizontal);

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0f) || !Mathf.Approximately(move.y, 0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("speed", move.magnitude);

        Vector2 position = rigidbody2d.position;

        position += move * speed * Time.deltaTime;

        rigidbody2d.MovePosition(position);

        /*if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }*/
    }

    /*public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

            animator.SetTrigger("Hit");
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }*/

    void Shoot()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, rigidbody2d.position + Vector2.up * .5f, Quaternion.identity);

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.Shoot(lookDirection, bullet.bulletSpeed);

        //animator.SetTrigger("Launch");
    }
}
