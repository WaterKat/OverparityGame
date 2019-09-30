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

        [SerializeField]
        float _duration;
        public float duration { get { if (_duration != 0) { return _duration; } else { return 3; } } }
    }
}