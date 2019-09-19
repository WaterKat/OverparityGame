using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WaterKat.WKInput
{
    public class ControllerTestUIButton : MonoBehaviour
    {
        public Toggle localToggle;

        public ControllerTestUI controllerTestUIMain;

        public string ButtonName;

        private void Update()
        {
            Debug.Log(controllerTestUIMain.TestingController + "Joystick_" + ButtonName);
            localToggle.isOn = Input.GetButton(controllerTestUIMain.TestingController + "Joystick_" + ButtonName);
        }

    }
}