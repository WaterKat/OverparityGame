using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class CharacterMovement2_5b : MonoBehaviour
{
    public float horizontalSpeed = 5f;
    public float verticalSpeed = 5f;
    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    public float timeInvincible = .5f;
    public float bulletSpeed = 5f;
    public GameObject bulletPrefab;
    public Sprite SonnyGun;
    public HealthBar healthBar;
    public bool hasGun = false;
    
    float HORIZ_SPEED;
    float VERT_SPEED;
    int currentHealth;
    [SerializeField]
    bool isInvincible;
    float invincibleTimer;
    float time1 = 0f;
    float time2 = 1f;
    Rigidbody2D rigidbody2d;
    Collider2D playerCollider;
    //Animator animator;
    Vector2 spawnPoint;
    Vector2 lookDirection = new Vector2(1, 0);

    Animator playerAnimator;

    void Start()
    {
        HORIZ_SPEED = horizontalSpeed;
        VERT_SPEED = verticalSpeed;
        currentHealth = maxHealth;

        playerAnimator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        spawnPoint = rigidbody2d.position;
        //animator = GetComponent<Animator>();
    }

    void UpdateAnimator()
    {
        playerAnimator.SetFloat("VelocityX", rigidbody2d.velocity.x);
        playerAnimator.SetFloat("VelocityY", rigidbody2d.velocity.y);
        playerAnimator.SetFloat("VelocityTotal", rigidbody2d.velocity.magnitude);
    }

    void Update()
    {
        UpdateAnimator();

        float H_Input = Input.GetAxis("Horizontal");
        float V_Input = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            horizontalSpeed = HORIZ_SPEED / 2;
            verticalSpeed = VERT_SPEED / 2;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            horizontalSpeed = HORIZ_SPEED * 2;
            verticalSpeed = VERT_SPEED * 2;
        }
        else if (Input.GetKeyDown(KeyCode.F) && hasGun)
        {
            time2 = Time.time;
            if (time2 - time1 >= .5)
            {
                Shoot();
                horizontalSpeed = 0;
                verticalSpeed = 0;
                time1 = Time.time;
            }
        }
        else if (Input.GetKeyUp(KeyCode.CapsLock) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.F)
            || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A)
            || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
            || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            horizontalSpeed = HORIZ_SPEED;
            verticalSpeed = VERT_SPEED;
        }

        rigidbody2d.velocity = new Vector2(H_Input * horizontalSpeed, V_Input * verticalSpeed);

        if ((!Mathf.Approximately(H_Input, 0f)) || !(Mathf.Approximately(V_Input, 0f)))
        {
            lookDirection.Set(H_Input, V_Input);
            lookDirection.Normalize();
        }

        //animator.SetFloat("Look X", lookDirection.x);
        //animator.SetFloat("Look Y", lookDirection.y);

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

        if (health <= 0)
        {
            rigidbody2d.transform.position = spawnPoint;
            currentHealth = maxHealth;
        }

        healthBar.Set(currentHealth, maxHealth);
    }

    void Shoot()
    {
        Vector2 offset;
        if (lookDirection.x < 0)
            offset = new Vector2(-.6f, .5f);
        else
            offset = new Vector2(.6f, .5f);
        GameObject bulletObject = Instantiate(bulletPrefab, rigidbody2d.position + offset, Quaternion.identity);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        if (lookDirection.x > 0)
            bullet.Shoot(lookDirection + new Vector2(1, 0), bulletSpeed);
        else
            bullet.Shoot(lookDirection + new Vector2(-1, 0), bulletSpeed);
    }

    public void getGun()
    {
        //this.GetComponent<SpriteRenderer>().sprite = SonnyGun;
        hasGun = true;
    }
}
