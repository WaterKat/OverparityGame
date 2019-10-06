using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonnyController : MonoBehaviour
{
    public float speed = 5f;
    public int maxHealth = 1;
    public int health { get { return currentHealth; } }
    public float timeInvincible = .5f;
    public float bulletSpeed = 50f;
    public GameObject bulletPrefab;
    public Sprite SonnyGun;

    float SPEED;
    int currentHealth;
    bool hasGun = false;
    bool isInvincible;
    float invincibleTimer;
    float time1 = 0f;
    float time2 = 1f;
    Rigidbody2D rigidbody2d;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    //Vector2 JumpForce = new Vector2(0, 7500);
    Vector2 SpawnPoint1 = new Vector2(-60f, -40f);

    void Start()
    {
        SPEED = speed;
        currentHealth = maxHealth;

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            speed = SPEED / 2;
            //animator.SetTrigger("Sneak");
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 2 * SPEED;
        }
        /*else if (Input.GetKeyDown(KeyCode.Space))
        {
            time2 = Time.time;
            if (time2 - time1 >= 1)
            {
                rigidbody2d.AddForce(JumpForce);
                time1 = Time.time;
            }
        }*/
        else if (Input.GetKeyDown(KeyCode.F))// && hasGun)
        {
            time2 = Time.time;
            if (time2 - time1 >= .5)
            {
                Shoot();
                speed = 0;
                time1 = Time.time;
            }     
        }
        else if (Input.GetKeyUp(KeyCode.CapsLock) ||  Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.F) 
            || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) 
            || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) 
            || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            speed = SPEED;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);

        if ((!Mathf.Approximately(move.x, 0f)) || !(Mathf.Approximately(move.y, 0f)))
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

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
            //animator.SetTrigger("Hit");
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //Debug.Log(currentHealth + "/" + maxHealth);
        if(health<=0)
        {
            rigidbody2d.transform.position = SpawnPoint1;
            ChangeHealth(1);
            speed = 0;
        }
    }

    void Shoot()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, rigidbody2d.position - new Vector2(0,0), Quaternion.identity);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.Shoot(lookDirection, bulletSpeed);
    }

    public void getGun()
    {
        this.GetComponent<SpriteRenderer>().sprite = SonnyGun;
        hasGun = true;
    }
}
