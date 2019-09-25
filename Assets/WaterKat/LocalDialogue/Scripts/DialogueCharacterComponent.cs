using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterKat.Time;

namespace WaterKat.Dialogue {
    public class DialogueCharacterComponent : MonoBehaviour
    {
        public DialogueCharacterInfo CharacterInfo;
        public GameObject BubblePrefab;
        public Vector2 Offset;
        public float BubbleFadeSpeed = 0.25f;

        bool _animating = false;
        public bool Animating { get { return _animating; } }

        GameObject Bubble;
        SpriteRenderer _spriteRenderer;
        SpriteRenderer spriteRenderer { get { if (_spriteRenderer == null) { _spriteRenderer = Bubble.GetComponent<SpriteRenderer>(); } return _spriteRenderer; } }
        
        void Start()
        {
            Bubble = Instantiate(BubblePrefab, transform);
            Bubble.SetActive(false);
            Bubble.transform.localPosition = Offset;
            Bubble.GetComponent<SpriteRenderer>().color = CharacterInfo.color;
        }

        private string fadeOutString;
        private string fadeoutLoopedString;

        [ContextMenu("FadeIn")]
        public void RequestDialogue(DialogueInfo info)
        {
            _animating = true;

            TimerManager.AddTask(InitiateFadeOut, info.duration, out fadeOutString);

            Bubble.SetActive(true);
            Color _color = spriteRenderer.color;
            _color.a = 0;
            spriteRenderer.color = _color;
            TimerManager.AddLoopedTask(FadeIn, BubbleFadeSpeed, out fadeoutLoopedString);
        }
        void FadeIn(float time)
        {
            Color _color = spriteRenderer.color;
            _color.a = time;
            spriteRenderer.color = _color;
        }

        [ContextMenu("FadeOut")]
        public void InitiateFadeOut()
        {
            TimerManager.AddLoopedTask(FadeOut, BubbleFadeSpeed);
            TimerManager.AddTask(FadeOutDelayed, BubbleFadeSpeed);
        }
        void FadeOutDelayed()
        {
            Bubble.SetActive(false);
            _animating = false;
        }
        void FadeOut(float time)
        {
            Color _color = spriteRenderer.color;
            _color.a = 1-time;
            spriteRenderer.color = _color;
        }

        public void AbortAnimation()
        {
            TimerManager.RemoveTask(fadeOutString);
            TimerManager.RemoveLoopedTask(fadeoutLoopedString);
            InitiateFadeOut();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}