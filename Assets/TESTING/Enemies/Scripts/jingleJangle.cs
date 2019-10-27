using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jingleJangle : MonoBehaviour
{
    public BlindBoss blindboss;

    void OnTriggerStay2D()
    {
        blindboss.triggered = true;
    }
}
