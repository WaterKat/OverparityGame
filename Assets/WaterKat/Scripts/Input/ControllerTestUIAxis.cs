using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WaterKat.WKInput {
    public class ControllerTestUIAxis : MonoBehaviour
    {
        public Slider localSlider;

        public ControllerTestUI controllerTestUIMain;

        public string AxisName;

        private void Update()
        {
            Debug.Log(controllerTestUIMain.TestingController + "Joystick_" + AxisName);
            localSlider.value = (Input.GetAxisRaw(controllerTestUIMain.TestingController + "Joystick_" + AxisName)/2)+0.5f;
        }

    }
}