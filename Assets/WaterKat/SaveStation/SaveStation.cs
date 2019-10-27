using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKat.SaveManagement
{
    [ExecuteInEditMode]
    public class SaveStation : MonoBehaviour
    {
        public int SaveStationID = 1;
        public Vector2 SpawnPosition = Vector2.down;

#if UNITY_EDITOR
        private static Dictionary<int, SaveStation> saveStations = new Dictionary<int, SaveStation>();
        private void FixDuplicates()
        {
            if (this.SaveStationID == 0) { return; }
            saveStations = new Dictionary<int, SaveStation>();
            SaveStation[] sceneSaveStations = GameObject.FindObjectsOfType<SaveStation>();
            foreach (SaveStation station in sceneSaveStations)
            {
                if (station.SaveStationID == 0) { continue; }
                if (station == this) { continue; }
                if (saveStations.ContainsKey(station.SaveStationID))
                {
                    station.SaveStationID = 1;
                    Debug.LogError("SaveStation: Duplicate Save Stations Found!");
                    Debug.Log(station.transform.parent + "/" + station.gameObject.name);
                }
                while (saveStations.ContainsKey(station.SaveStationID))
                {
                    station.SaveStationID++;
                }
                station.gameObject.name = "SaveStation:" + station.SaveStationID;
                saveStations.Add(station.SaveStationID, station);
            }
            SaveStationID = saveStations.Count + 1;
            gameObject.name = "SaveStation:" + SaveStationID;
        }
#endif
        private void Awake()
        {
#if UNITY_EDITOR
            FixDuplicates();
#endif
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position + (Vector3)SpawnPosition, 0.5f);
        }
    }
}