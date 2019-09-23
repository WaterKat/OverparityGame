using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WaterKat.UI
{
    [ExecuteInEditMode]
    public class GradientTimer : MonoBehaviour
    {
        [Range(0,1)]
        public float Time;
        public RectTransform leftTimer;
        public RectTransform rightTimer;

        void Update()
        {
            leftTimer.anchorMin = new Vector2(Mathf.Clamp(Time,0,1) / 2, 0);
            leftTimer.anchorMax = new Vector2(.5f, 1);

            rightTimer.anchorMin = new Vector2(0.5f, 0);
            rightTimer.anchorMax = new Vector2(0.5f + ((1-Mathf.Clamp(Time, 0, 1)) / 2), 1);
        }
    }
}