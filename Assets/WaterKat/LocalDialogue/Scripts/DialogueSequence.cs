using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WaterKat.Dialogue
{
    [CreateAssetMenu(fileName = "New DialogueSequence", menuName = "JordanHall/DialogueSequence", order = 1)]
    public class DialogueSequence : ScriptableObject
    {
        public DialogueInfo[] Dialogue;
    }

    [System.Serializable]
    public struct DialogueInfo
    {
        public DialogueCharacterInfo character;

        public AudioClip audio;

        public string dialogue;
        public float duration;
    }

}