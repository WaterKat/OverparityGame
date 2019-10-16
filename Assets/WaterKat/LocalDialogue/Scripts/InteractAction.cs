using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKat.Dialogue
{


    public class InteractAction : MonoBehaviour
    {
        public float InteractableRadius = 2.5f;

        DialogueInteractableObject FindClosestInteractableObject()
        {
            Collider2D[] collidersWithinRadius = Physics2D.OverlapCircleAll(transform.position, InteractableRadius);
            float CloseDistance = InteractableRadius + 1;
            Collider2D ClosestCollider = null;
            DialogueInteractableObject ClosestInteractable = null;
            foreach (Collider2D collider2D in collidersWithinRadius)
            {
                DialogueInteractableObject interactable = collider2D.gameObject.GetComponent<DialogueInteractableObject>();
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

        DialogueInteractableObject CurrentInteractable;
        DialogueInteractableObject lastinteractableObject;

        void Update()
        {
            CurrentInteractable = FindClosestInteractableObject();
            if (CurrentInteractable != null)
            {

                CurrentInteractable.Selected = true;
                //AnimateInteration();
            }
            if ((lastinteractableObject != null) && (lastinteractableObject != CurrentInteractable))
            {
                lastinteractableObject.Selected = false;
            }
            lastinteractableObject = CurrentInteractable;

            bool inputBool = Input.GetKeyDown("e");
            if ((inputBool)&&(CurrentInteractable!=null))
            {
                if (!DialogueManager.main.Animating)
                {
                    DialogueManager.main.RequestDialogue(CurrentInteractable.currentActiveDialogue);
                    CurrentInteractable.TickTowardsNextDialogue();
                }
                else
                {
                    DialogueManager.main.AbortDialogue();
                }
            }

        }
    }
}
