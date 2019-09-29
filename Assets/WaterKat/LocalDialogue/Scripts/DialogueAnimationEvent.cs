using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKat.Dialogue
{
    public class DialogueAnimationEvent : MonoBehaviour
    {
        public DialogueSequence dialogueSequence;

        public int currentDialogue;

        DialogueInfo currentActiveDialogue
        {
            get { return dialogueSequence.Dialogue[currentDialogue]; }
        }

        void TickTowardsNextDialogue()
        {
            //      Debug.Log(dialogueSequence.Dialogue[currentDialogue]);
            currentDialogue = (int)Mathf.Repeat(currentDialogue + 1, dialogueSequence.Dialogue.Count);
        }


        public void AbortDialogue()
        {
            DialogueManager.main.AbortDialogue();
        }
        public void ActivateDialogue()
        {
            DialogueManager.main.RequestDialogue(dialogueSequence.Dialogue[currentDialogue]);
            TickTowardsNextDialogue();
        }
    }
}