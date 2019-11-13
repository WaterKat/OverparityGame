using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossJingleJangle : MonoBehaviour
{
    public FinalBoss fb;

    void OnTriggerEnter2D()
    {
        fb.triggered = true;
    }
}
