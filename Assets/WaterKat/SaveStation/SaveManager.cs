using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WaterKat.SaveManagement
{
    public class SaveManager : MonoBehaviour
    {
        public class Save
        {
            public int CurrentSaveStation = 0;
            public string CurrentScene = "Level_1";
        }

        public int LastActiveSaveStation = 0;

        private static SaveManager _instance;
        public static SaveManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<SaveManager>();
                    return _instance;
                }
                else
                {
                    return _instance;
                }
            }
        }
    }
}