using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WaterKat.Dialogue
{
    [CreateAssetMenu(fileName = "New DialogueSequence", menuName = "JordanHall/DialogueSequence", order = 1)]
    public class DialogueSequence : ScriptableObject
    {
        [HideInInspector] // we do this beacause we call base.OnInspectorGUI(); And we don't want that to draw the list aswell.
        public List<DialogueInfo> Dialogue;
    }


}