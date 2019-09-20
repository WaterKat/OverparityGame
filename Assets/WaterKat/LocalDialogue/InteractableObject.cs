using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKat.Dialogue
{
    public class InteractableObject : MonoBehaviour
    {
        public DialogueSequence dialogueSequence;

        public int currentDialogue;

        public void Speak()
        {
            Debug.Log(dialogueSequence.Dialogue[currentDialogue]);
            currentDialogue = (int)Mathf.Repeat(currentDialogue + 1, dialogueSequence.Dialogue.Length - 1);
        }
    }
}