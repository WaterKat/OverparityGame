using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterKat.Time;
using WaterKat.UI;

namespace WaterKat.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public DialogueInfo dialogueInfo;

        [ContextMenu("TestDialogueInfo")]
        void rundialoguetest()
        {
            StartDialogue(dialogueInfo);
        }
        public void StartDialogue(DialogueInfo info)
        {
            DialogueCharacterComponent _dialogueCharacter= FindCharacterComponent(info.character);
            if (_dialogueCharacter != null)
            {
                _dialogueCharacter.InitiateFadeIn();
                TimerManager.AddTask(_dialogueCharacter.InitiateFadeOut, dialogueInfo.duration);
            }
            GameObject.FindObjectOfType<DialogueCanvasUI>().RequestDialogue(info);
        }
    
        DialogueCharacterComponent FindCharacterComponent(DialogueCharacterInfo characterInfo)
        {
            DialogueCharacterComponent[] characterComponents = GameObject.FindObjectsOfType<DialogueCharacterComponent>();
            foreach  (DialogueCharacterComponent dialogueCharacter in characterComponents)
            {
                if (dialogueCharacter.CharacterInfo == characterInfo)
                {
                    return dialogueCharacter;
                }
            }
            return null;
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}