using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthbar;
    float maxhealth = 5f;
    public static float health;
    void Start()
    {
        healthbar = GetComponent<Image>();
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = health / maxhealth;
    }
}
