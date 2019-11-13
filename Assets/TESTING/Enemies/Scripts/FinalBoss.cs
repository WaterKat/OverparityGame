using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class FinalBoss : MonoBehaviour
{
    public int MaxX = 150;
    public int YMove = 30;
    float xDistMoved = 0;
    bool aggro1 = true;

    public bool triggered = false;

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

    Vector2 position1, position2, position3, position4;
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        position1 = enemyRigidbody.position;
        position2 = enemyRigidbody.position;
        position3 = enemyRigidbody.position;
        position4 = enemyRigidbody.position;
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
        if (triggered)
        {
            Vector2 desiredDirection = Pursue();
            enemyRigidbody.velocity = Vector2.Scale(desiredDirection, Velocity);

            if (position1 == null)
                position1 = enemyRigidbody.position;
            else if (position2 == null)
                position2 = enemyRigidbody.position;
            else if (position3 == null)
                position3 = enemyRigidbody.position;
            else if (position4 == null)
                position4 = enemyRigidbody.position;
            else
            {
                position1 = position2;
                position2 = position3;
                position3 = position4;
                position4 = enemyRigidbody.position;
                MoveIt();
            }

            if (aggro1)
            {
                xDistMoved += (position4.x + position3.x) - (position2.x + position1.x);
                Debug.Log(xDistMoved);
                if (xDistMoved > MaxX)
                {
                    triggered = false;
                    aggro1 = false;
                    enemyRigidbody.velocity = new Vector2(0f, 0f);
                    enemyRigidbody.position += new Vector2(0f, YMove);
                }
            }     
        }
    }

    Vector2 Pursue()
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

        return desiredDirection;
    }

    void MoveIt()
    {
        Vector2 desiredDirection;
        //CharacterMovement2_5b sonny = other.collider.GetComponent<CharacterMovement2_5b>();

        //if (sonny == null)
        {
            Vector2 deltaPosition = (position4 + position3) - (position2 + position1);
            //Debug.Log((position4 + position3) - (position2 + position1));
            desiredDirection = Pursue();

            if (Mathf.Approximately(deltaPosition.magnitude, 0))
            {
                enemyRigidbody.transform.position -= new Vector3(desiredDirection.x * Velocity.x, desiredDirection.y * Velocity.y);
            }
        }
    }
}