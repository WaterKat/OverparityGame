using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBjingleJangle : MonoBehaviour
{
    public BlindBoss blindboss;

    void OnTriggerEnter2D()
    {
        blindboss.triggered = true;
    }
}
