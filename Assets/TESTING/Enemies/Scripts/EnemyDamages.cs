using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamages : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D other)
    {
        CharacterMovement2_5b sonny = other.gameObject.GetComponent<CharacterMovement2_5b>();
        if (sonny != null)
        {
            sonny.ChangeHealth(-1);
        }
    }
}
