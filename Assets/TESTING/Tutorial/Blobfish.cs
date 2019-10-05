using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blobfish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        HealthBar.health -= 1f;
    }

   
}
