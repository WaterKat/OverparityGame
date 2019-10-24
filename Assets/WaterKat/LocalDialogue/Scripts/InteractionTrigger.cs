using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKat.Dialogue
{
    public class InteractionTrigger : MonoBehaviour
    { 
        private void AnimateInteration()
        {
            throw new NotImplementedException();
        }

        public DialogueSequence _dialogueSequence;
        public int CurrentDialogue = 0;

        void dialogue()
        {
            DialogueManager.main.RequestDialogue(_dialogueSequence.Dialogue[CurrentDialogue], TriggerNextDialogue);
            CurrentDialogue = (int)Mathf.Repeat(CurrentDialogue+1,_dialogueSequence.Dialogue.Count);
        }
        private void TriggerNextDialogue()
        {
            if (CurrentDialogue != 0)
            {
                dialogue();
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Touched");
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("is PLayer");
                dialogue();
            }
        }
    }
}
