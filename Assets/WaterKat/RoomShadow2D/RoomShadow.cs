using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomShadow : MonoBehaviour
{
    public Color shadowColorDark = Color.black;
    public Color shadowColorBright = new Color(0, 0, 0, 0);

    public float FadeTime = 1;

    float fadeValue = 0;
    SpriteRenderer shadowRenderer;

    Collider2D shadowCollider;
    // Start is called before the first frame update
    void Start()
    {
        shadowCollider = GetComponent<Collider2D>();
        shadowRenderer = GetComponent<SpriteRenderer>();
        shadowRenderer.color = shadowColorDark;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            if (shadowCollider.OverlapPoint(playerObject.transform.position))
            {
                fadeValue += 1/FadeTime * Time.deltaTime;
            }
            else
            {
                fadeValue -= 1/FadeTime * Time.deltaTime;
            }
        }
        else
        {
            fadeValue -= 1 / FadeTime * Time.deltaTime;
        }
        fadeValue = Mathf.Clamp(fadeValue, 0, 1);

        shadowRenderer.color = Color.Lerp(shadowColorDark, shadowColorBright, fadeValue);
    }
}
