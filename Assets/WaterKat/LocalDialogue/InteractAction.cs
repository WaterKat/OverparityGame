using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKat.Dialogue
{


    public class InteractAction : MonoBehaviour
    {
        public float InteractableRadius = 2.5f;

        InteractableObject FindClosestInteractableObject()
        {
            Collider2D[] collidersWithinRadius = Physics2D.OverlapCircleAll(transform.position, InteractableRadius);
            float CloseDistance = InteractableRadius + 1;
            Collider2D ClosestCollider = null;
            InteractableObject ClosestInteractable = null;
            foreach (Collider2D collider2D in collidersWithinRadius)
            {
                InteractableObject interactable = collider2D.gameObject.GetComponent<InteractableObject>();
                if (interactable == null) { continue; }

                float distanceToCollider = Vector2.Distance(collider2D.transform.position, transform.position);
                if (distanceToCollider < CloseDistance)
                {
                    ClosestCollider = collider2D;
                    CloseDistance = distanceToCollider;
                    ClosestInteractable = interactable;
                }
            }
            return ClosestInteractable;
        }

        private void AnimateInteration()
        {
            throw new NotImplementedException();
        }

        InteractableObject lastinteractableObject;

        void Update()
        {
            bool InteractionInput = true; ;
        //    InteractionInput = Input.GetKeyDown("e");

            if (InteractionInput)
            {
                InteractableObject interactable = FindClosestInteractableObject();
                if (interactable != null)
                {

                    interactable.Active = true;
                    //AnimateInteration();
                }
                if ((lastinteractableObject != null) && (lastinteractableObject != interactable))
                {
                    lastinteractableObject.Active = false;
                }
                lastinteractableObject = interactable;
            }
        }


    }
}
