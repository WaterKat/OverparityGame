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

    [System.Serializable]
    class Ticker
    {
        float currentTick = 0;
        public float MaxTick = 1;

        public bool TryTick()
        {
            if (currentTick > MaxTick) { currentTick = 0; }
            currentTick += Time.deltaTime;
            return currentTick >= MaxTick;
        }
    }

    [SerializeField]
    Ticker Idle = new Ticker();
    [SerializeField]
    Ticker PointPatrol = new Ticker();
    [SerializeField]
    Ticker Aggro = new Ticker();
    [SerializeField]
    Ticker Tired = new Ticker();
    [SerializeField]
    Ticker Stun = new Ticker();

    [SerializeField]
    List<Vector2> PatrolPath = new List<Vector2>();

    public Vector2 PatrolPoint = Vector2.zero;
    public Vector2 offSetPatrolPoint = Vector2.zero;
    public float patrolDistance = 1;

    public float AggroDistance = 3;

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
        Vector2 desiredDirection = Vector2.zero;
        switch (enemyState)
        {
            case EnemyState.Idle:
                enemyState = EnemyState.PointPatrol;
                break;
            case EnemyState.PointPatrol:
                enemyState = EnemyState.PointPatrol;
                if (PointPatrol.TryTick())
                {
                    offSetPatrolPoint = PatrolPoint + new Vector2(Random.Range(-patrolDistance, patrolDistance), Random.Range(-patrolDistance, patrolDistance));
                }
                desiredDirection = ((Vector3)offSetPatrolPoint - transform.position);
                if (UpdateTargetPlayer())
                {
                    if (Vector3.Distance(activePlayer.transform.position, transform.position) < AggroDistance)
                    {
                        enemyState = EnemyState.Aggro;
                    }
                }
                break;
            case EnemyState.PathPatrol:
                break;
            case EnemyState.Aggro:
                if (UpdateTargetPlayer())
                {
                    desiredDirection = activePlayer.transform.position - transform.position;
                    if (Vector3.Distance(activePlayer.transform.position, transform.position) > AggroDistance)
                    {
                        enemyState = EnemyState.Idle;
                    }
                }
                else
                {
                    enemyState = EnemyState.Tired;
                }
                if (Aggro.TryTick())
                {
                    enemyState = EnemyState.Tired;
                }
                break;
            case EnemyState.Stun:
                if (Stun.TryTick())
                {
                    enemyState = EnemyState.Idle;
                }
                break;
            case EnemyState.Tired:
                if (Tired.TryTick())
                {
                    enemyState = EnemyState.Idle;
                }
                break;
        }

        enemyRigidbody.velocity = Vector2.Scale(desiredDirection.normalized * Mathf.Max(Mathf.Min(desiredDirection.magnitude / Velocity.magnitude, 1), 1), Velocity);
    }
}