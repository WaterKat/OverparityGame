using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class StandardEnemyCrawl : MonoBehaviour
{
    public enum EnemyState
    {
        Idle = 0,
        PointPatrol = 1,
        PathPatrol = 2,
        Aggro = 3,
        Tired = 4,
        Stun = 5,
    }

    public EnemyState enemyState;

    public Vector2 Velocity = new Vector2(3, 1);

    [SerializeField]
    List<Vector2> PatrolPath = new List<Vector2>();

    [SerializeField]
    GameObject activePlayer;

    Rigidbody2D enemyRigidbody;
    //Collider2D enemyCollider;
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        //enemyCollider = GetComponent<Collider2D>();
    }

    private bool UpdateTargetPlayer()
    {
        activePlayer = GameObject.FindGameObjectWithTag("Player");
        return activePlayer != null;
    }

    void OnDrawGizmosSelected()
    {
        
        if (activePlayer != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, 1);
        }
    }

    void Update()
    {
        Vector2 desiredDirection;

        if (UpdateTargetPlayer())
        {
            desiredDirection = (activePlayer.transform.position - transform.position).normalized;
        }
        else
        {
            desiredDirection = Vector2.zero;
        }

        enemyRigidbody.velocity = Vector2.Scale(desiredDirection, Velocity);
    }
}