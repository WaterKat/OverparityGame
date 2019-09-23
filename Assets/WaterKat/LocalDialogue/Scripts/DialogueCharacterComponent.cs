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
        [ContextMenu("FadeIn")]
        public void InitiateFadeIn()
        {
            Bubble.SetActive(true);
            Color _color = spriteRenderer.color;
            _color.a = 0;
            spriteRenderer.color = _color;
            TimerManager.AddLoopedTask(FadeIn, BubbleFadeSpeed);
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
        }
        void FadeOut(float time)
        {
            Color _color = spriteRenderer.color;
            _color.a = 1-time;
            spriteRenderer.color = _color;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}