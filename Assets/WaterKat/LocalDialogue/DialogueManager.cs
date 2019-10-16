using UnityEngine;
using WaterKat.Time;
using WaterKat.UI;
using WaterKat.Audio;

namespace WaterKat.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        private static DialogueManager _main;
        public static DialogueManager main
        {
            get
            {
                if (_main != null)
                {
                    return _main;
                }
                DialogueManager manager = GameObject.FindObjectOfType<DialogueManager>();
                if (manager != null)
                {
                    _main = manager;
                    return manager;
                }
                else
                {
                    DialogueManager newManager = new GameObject().AddComponent<DialogueManager>();
                    newManager.gameObject.name = "DialogueManager";
                    DontDestroyOnLoad(newManager.gameObject);
                    _main = newManager;
                    return newManager;
                }
            }
        }

        public DialogueInfo dialogueInfo;

        public bool Animating
        {
            get
            {
                bool animating = false;
                DialogueCharacterComponent _dialogueCharacterBubble = FindCharacterComponent(dialogueInfo.character);
                if (_dialogueCharacterBubble != null)
                {
                   animating = (_dialogueCharacterBubble.Animating || animating);
                }
                DialogueCanvasUI _dialogueCanvas = GameObject.FindObjectOfType<DialogueCanvasUI>();
                if (_dialogueCanvas != null)
                {
                    animating = (_dialogueCanvas.Animating || animating);
                }
                return animating;
            }
        }

        [ContextMenu("TestDialogueInfo")]
        void rundialoguetest()
        {
            RequestDialogue(dialogueInfo);
        }

        public void RequestDialogue(DialogueInfo info)
        {
            if (Animating) { return; }

            dialogueInfo = info;
            DialogueCharacterComponent _dialogueCharacterBubble = FindCharacterComponent(info.character);
            if (_dialogueCharacterBubble != null)
            {
                _dialogueCharacterBubble.RequestDialogue(info);
            }
            DialogueCanvasUI _dialogueCanvas = GameObject.FindObjectOfType<DialogueCanvasUI>();
            if (_dialogueCanvas != null)
            {
                _dialogueCanvas.RequestDialogue(info);
            }
            if (info.audio.Length > 0)
            {
                AudioManager.PlaySound(info.audio);
            }
        }

        [ContextMenu("Abort")]
        public void AbortDialogue()
        {
            DialogueCharacterComponent _dialogueCharacterBubble = FindCharacterComponent(dialogueInfo.character);
            if (_dialogueCharacterBubble != null)
            {
                _dialogueCharacterBubble.AbortAnimation();
            }
            DialogueCanvasUI _dialogueCanvas = GameObject.FindObjectOfType<DialogueCanvasUI>();
            if (_dialogueCanvas != null)
            {
                _dialogueCanvas.AbortAnimation();
            }
            if (dialogueInfo.audio.Length > 0)
            {
                AudioManager.StopSound(dialogueInfo.audio);
            }
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
        private void Awake()
        {
            if (transform.parent == null)
            {
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(transform.parent.gameObject);
            }
            }
    }
}