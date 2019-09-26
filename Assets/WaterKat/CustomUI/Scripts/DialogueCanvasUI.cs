using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

using WaterKat.Time;
using WaterKat.Dialogue;

namespace WaterKat.UI
{
    [ExecuteInEditMode]
    public class DialogueCanvasUI : MonoBehaviour
    {
        public List<DialogueInfo> dialogueInfos = new List<DialogueInfo>();
        DialogueInfo currentDialogue
        {
            get { return dialogueInfos[0]; }
        }
        public float FadeInTime = 0.25f;

        public bool Animating = false;

        public Image LeftBackgroundGradient;
        public Image RightBackgroundGradient;
        public Color BackgroundGradientColor = Color.black;

        public TextMeshProUGUI characterName;
        public TextMeshProUGUI characterDialogue;
        public Color DialogueColor = Color.white;

        public Image LeftTimeGradient;
        public Image RightTimeGradient;
        public GradientTimer gradientTimer;


        void Start()
        {
            SetupAnimations();
        }
        public void SetupAnimations()
        {
            LeftBackgroundGradient.color = new Color(0, 0, 0, 0);
            RightBackgroundGradient.color =new Color(0, 0, 0, 0);
            characterName.color = new Color(0, 0, 0, 0);
            characterDialogue.color =new Color(0, 0, 0, 0);
            LeftTimeGradient.color = new Color(0, 0, 0, 0);
            RightTimeGradient.color = new Color(0, 0, 0, 0);
        }
        public void FadeInAnimation(float time)
        {
            LeftBackgroundGradient.color = Color.Lerp(new Color(0, 0, 0, 0), BackgroundGradientColor, time);
            RightBackgroundGradient.color = Color.Lerp(new Color(0, 0, 0, 0), BackgroundGradientColor, time);
            characterName.color = Color.Lerp(new Color(0, 0, 0, 0), currentDialogue.character.color, time);
            characterDialogue.color = Color.Lerp(new Color(0, 0, 0, 0), DialogueColor, time);
            LeftTimeGradient.color = Color.Lerp(new Color(0, 0, 0, 0), currentDialogue.character.color, time);
            RightTimeGradient.color = Color.Lerp(new Color(0, 0, 0, 0), currentDialogue.character.color, time);
        }
        public void FadeOutWithDelay()
        {
            TimerManager.AddLoopedTask(FadeOutAnimation, FadeInTime);
        }
        public void FadeOutAnimation(float timei)
        {
            float time = 1 - timei;
            LeftBackgroundGradient.color = Color.Lerp(new Color(0, 0, 0, 0), BackgroundGradientColor, time);
            RightBackgroundGradient.color = Color.Lerp(new Color(0, 0, 0, 0), BackgroundGradientColor, time);
            characterName.color = Color.Lerp(new Color(0, 0, 0, 0), currentDialogue.character.color, time);
            characterDialogue.color = Color.Lerp(new Color(0, 0, 0, 0), DialogueColor, time);
            LeftTimeGradient.color = Color.Lerp(new Color(0, 0, 0, 0), currentDialogue.character.color, time);
            RightTimeGradient.color = Color.Lerp(new Color(0, 0, 0, 0), currentDialogue.character.color, time);
        }
        public void UpdateGradientTimer(float time)
        {
            gradientTimer.Time = time;
        }
        public void FinishAnimation()
        {
            Animating = false;
        }

        [ContextMenu("EarlyAbort")]
        public void AbortAnimation()
        {
            TimerManager.RemoveLoopedTask(gradientID);
            TimerManager.RemoveTask(fadeOutID);
            TimerManager.RemoveTask(endAnimID);
            FadeOutWithDelay();
            TimerManager.AddTask(FinishAnimation, FadeInTime);
        }
        string gradientID;
        string fadeOutID;
        string endAnimID;
        [ContextMenu("TestFadeIn")]
        public void TextFadeIn()
        {
            if (dialogueInfos.Count<1) { return; }
            Animating = true;
            characterName.text = currentDialogue.character.name + ": ";
            characterDialogue.text = currentDialogue.dialogue;
            TimerManager.AddLoopedTask(FadeInAnimation, FadeInTime);
            TimerManager.AddLoopedTask(UpdateGradientTimer, currentDialogue.duration,out gradientID);
            TimerManager.AddTask(FadeOutWithDelay, currentDialogue.duration,out fadeOutID);
            TimerManager.AddTask(FinishAnimation, currentDialogue.duration + FadeInTime, out endAnimID);
        }

        public void RequestDialogue(DialogueInfo info)
        {
            dialogueInfos = new List<DialogueInfo>() { info };
            TextFadeIn();
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}