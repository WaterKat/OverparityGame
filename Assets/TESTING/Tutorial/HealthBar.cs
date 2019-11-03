using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Transform bar;

    void Start()
    {
        bar = transform.Find("healthbar");
        //bar.localScale = new Vector2(50f, 50f);
    }

    public void Set(int currentHealth, int maxHealth)
    {
        //Debug.Log(currentHealth);
        bar.localScale = new Vector2(((float)currentHealth / maxHealth)*50, 50f);
    }
}
