using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKat.Dialogue
{
    [CreateAssetMenu(fileName = "New DialogueCharacterInfo", menuName = "JordanHall/DialogueCharacterInfo", order = 1)]
    [System.Serializable]
    public class DialogueCharacterInfo : ScriptableObject
    {
        public string characterName;
        public Color color;
    }
}