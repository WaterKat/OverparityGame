using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTentacles : MonoBehaviour
{
    public GameObject Tentacle;
    public int tentaclecount;
    public float ringsize;

    [ContextMenu("placetentacles")]
    void Tentacles()
    {
        GameObject holder = new GameObject(); 
        for (int i = 0; i < tentaclecount; i++)
        {
            GameObject newTentacle = Instantiate(Tentacle);
            newTentacle.transform.position = new Vector3(Mathf.Cos((float)i/tentaclecount * Mathf.PI * 2) * ringsize,Mathf.Sin((float)i/tentaclecount * Mathf.PI * 2) * ringsize,0);
            newTentacle.transform.parent = holder.transform;
        }
    }
}
