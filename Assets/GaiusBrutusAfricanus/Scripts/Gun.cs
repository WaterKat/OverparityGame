using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        SonnyController sonny = other.GetComponent<SonnyController>();
        if(sonny != null)
        {
            Destroy(this.gameObject);
            sonny.getGun();
        }
    }
}
