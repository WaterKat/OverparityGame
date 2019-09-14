using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKat.VGDA
{
    public class PlayerController : MonoBehaviour
    {
        public static float Gravity = 10;
        public static Vector3 GravityDirection = Vector3.down;

        public Vector3 Velocity = Vector3.zero;

        Rigidbody2D rigidBody2D;

        public Collider2D GroundCollider;

        private void Awake()
        {
            rigidBody2D = GetComponent<Rigidbody2D>();
            if (GroundCollider == null) { Debug.LogError("No ground collider assigned!"); this.enabled = false; }
        }
        /*
        bool CheckForGround()
        {
            bool _grounded = false;
            RaycastHit2D[] raycastHit2Ds = new RaycastHit2D[5];
            Vector3 projectedVector = Vector3.Project(Velocity, GravityDirection.normalized);
            int HitCount = GroundCollider.Cast(GravityDirection, raycastHit2Ds, projectedVector.magnitude*Time.fixedDeltaTime, true);
            if (HitCount > 0)
            {
                for (int i = 0; i < Mathf.Min(raycastHit2Ds.Length,HitCount); i++)
                {
                    Debug.DrawLine(transform.position, raycastHit2Ds[i].point, Color.blue, .1f);

                    float pointDistance = Vector3.Distance(raycastHit2Ds[i].point, transform.position);
                    if ( pointDistance < GroundDistance)
                    {
                        GroundDistance = pointDistance;
                    }

                    _grounded = true;
                }
            }
            return _grounded;
        }
        */

        bool CollisionCheck()
        {
            bool Colliding = false;
            Vector3 deltaMovement = Velocity * Time.fixedDeltaTime;

            RaycastHit2D[] raycastHits = new RaycastHit2D[10];
            int HitCount = GroundCollider.Cast(Velocity.normalized, raycastHits, deltaMovement.magnitude, true);

            if (HitCount > 0)
            {
                float ClosestDistance = 5;
                Vector2 closestBound = Vector3.zero;
                RaycastHit2D closestHit = new RaycastHit2D();
                for (int i = 0; i < Mathf.Min(HitCount,raycastHits.Length); i++)
                {
                    Debug.DrawLine(transform.position, raycastHits[i].point,Color.red,.1f);

                    Vector3 _closestBound = GroundCollider.bounds.ClosestPoint(raycastHits[i].point);
                    float pointDistance = Vector3.Distance(_closestBound, raycastHits[i].point);
                    if (pointDistance < ClosestDistance)
                    {
                        ClosestDistance = pointDistance;
                        closestBound = _closestBound;
                        closestHit = raycastHits[i];
                    }
                }
                Vector2 ClosestBoundOther = closestHit.collider.bounds.ClosestPoint(closestHit.point);
                Vector2 Penetration = ClosestBoundOther - closestHit.point;
                // Debug.Log(Penetration);

                transform.position = (Vector2)transform.position + (closestHit.point - closestBound);
                Debug.DrawLine(closestHit.point, closestBound, Color.cyan, 0.1f);
               // Debug.Break();
                //rigidBody2D.MovePosition((Vector2)transform.position + (closestHit.point - closestBound));
                Vector3 collisionvelocity = Vector3.Project(Velocity, closestBound - closestHit.point);
                if (GroundCollider.OverlapPoint(closestHit.point))
                {
                    Debug.Log("INSIDE");
                    Velocity += (Vector3)closestHit.normal * 10*Time.deltaTime;
                }
                Debug.Log(collisionvelocity);
                
                Velocity += -collisionvelocity;
                Velocity *= .99f;
               // Debug.Break();
                Colliding = true;
            }
            else
            {
              transform.position = transform.position + (Velocity * Time.deltaTime);
            }

            return Colliding;
        }


        private void Update()
        {
            bool colliding = CollisionCheck();
            if (!colliding)
            {
                Velocity += (GravityDirection.normalized * Gravity) * Time.deltaTime;
            }

        }
    }
}