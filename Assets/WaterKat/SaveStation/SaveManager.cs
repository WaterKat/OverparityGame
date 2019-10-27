using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WaterKat.SaveManagement
{
    public class SaveManager : MonoBehaviour
    {
        [System.Serializable]
        public class Save
        {
            public int CurrentSaveStation = 0;
            public string CurrentScene = "Level_1";
        }

        
        public Save CurrentSave = new Save();

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

        public static void SetSaveStation(int station)
        {
            station = (int)Mathf.Max(0, station);
            SaveManager.instance.CurrentSave.CurrentSaveStation = station;
            SaveManager.instance.CurrentSave.CurrentScene = SceneManager.GetActiveScene().name;
        }
        [ContextMenu("SaveFile")]
        public void SaveGame()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/"+SceneManager.GetActiveScene().name+".save");
            bf.Serialize(file, CurrentSave);
            file.Close();
            Debug.Log("Game Saved");
        }

        Vector3 spawnPos = Vector3.one * 20;
        private void OnLevelWasLoaded(int level)
        {
            GameObject.FindWithTag("Player").transform.position = spawnPos;
        }
        private void Start()
        {
            SaveStation[] saveStations = FindObjectsOfType<SaveStation>();
            SaveStation saveFileSaveStation = FindObjectOfType<SaveStation>();
            foreach (SaveStation saveStation in saveStations)
            {
                if (saveStation.SaveStationID == CurrentSave.CurrentSaveStation)
                {
                    saveFileSaveStation = saveStation;
                    break;
                }
                else
                {
                    if (saveStation.SaveStationID == 0)
                    {
                        saveFileSaveStation = saveStation;
                        break;
                    }
                }
            }
            if (saveFileSaveStation != null)
            {
                spawnPos = saveFileSaveStation.transform.position + (Vector3)saveFileSaveStation.SpawnPosition;
                OnLevelWasLoaded(0);
            }
        }

        [ContextMenu("LoadFile")]
        public void LoadGame()
        {
            // 1
            if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
            {
                // 2
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
                CurrentSave = (Save)bf.Deserialize(file);
                file.Close();
                SceneManager.LoadScene(CurrentSave.CurrentScene);
                SaveStation[] saveStations = FindObjectsOfType<SaveStation>();
                SaveStation saveFileSaveStation = FindObjectOfType<SaveStation>();
                foreach (SaveStation saveStation in saveStations)
                {
                    if (saveStation.SaveStationID == CurrentSave.CurrentSaveStation)
                    {
                        saveFileSaveStation = saveStation;
                        break;
                    }
                    else
                    {
                        if (saveStation.SaveStationID == 0)
                        {
                            saveFileSaveStation = saveStation;
                            break;
                        }
                    }
                }
                if (saveFileSaveStation != null)
                {
                    spawnPos = saveFileSaveStation.transform.position + (Vector3)saveFileSaveStation.SpawnPosition;
                }
            }
        }
    }
}