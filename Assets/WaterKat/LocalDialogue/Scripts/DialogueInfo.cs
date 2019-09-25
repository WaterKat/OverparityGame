using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKat.Dialogue
{
    [System.Serializable]
    public struct DialogueInfo
    {
        public DialogueCharacterInfo character;

        public string audio;

        public string dialogue;
        public float duration;
    }
}