using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        CharacterMovement2_5b sonny = other.GetComponent<CharacterMovement2_5b>();
        if(sonny != null)
        {
            sonny.getGun();
            Destroy(this.gameObject);
        }
    }
}
