using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using WaterKat.Inventory;

namespace WaterKat.Dialogue
{
    [RequireComponent(typeof(Collider2D))]
    public class DialogueInteractableObject : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        public Material defaultMaterial;
        public Material outlineMaterial;

        public string desiredMethodName = "";
        public InventoryGiver inventoryScript;
        [SerializeField]
        public Action desiredAction;

        public bool _active = false;
        public bool Selected
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
                if (_active)
                {
                    spriteRenderer.material = outlineMaterial;
                }
                else
                {
                    spriteRenderer.material = defaultMaterial;
                }
            }
        }

        private void Start()
        {
            Selected = false;

           
        }

        public DialogueSequence dialogueSequence;

        public int currentDialogue;

        public DialogueInfo currentActiveDialogue
        {
            get { return dialogueSequence.Dialogue[currentDialogue]; }
        }

        public void RequesCurrentDialogue()
        {

            if (currentActiveDialogue.LoadNextDialogue)
            {
                DialogueManager.main.RequestDialogue(currentActiveDialogue,RunNextDialogue);
            }
            else
            {
                DialogueManager.main.RequestDialogue(currentActiveDialogue);
                Debug.Log("NotLoadingNext");
            }
        }

        public void RunNextDialogue()
        {
            Debug.Log("Requesting");
            TickTowardsNextDialogue();
            RequesCurrentDialogue();
        }

        public void CallAction(GameObject player)
        {
            if (inventoryScript == null) { return; }
            inventoryScript.TargetPlayer = player;
            inventoryScript.GiveItemToPlayer();
        }

        public void TickTowardsNextDialogue()
        {
      //      Debug.Log(dialogueSequence.Dialogue[currentDialogue]);
            currentDialogue = (int)Mathf.Repeat(currentDialogue + 1, dialogueSequence.Dialogue.Count);
        }
    }
}