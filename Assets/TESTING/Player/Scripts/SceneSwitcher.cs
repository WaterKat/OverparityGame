using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string menu;
    public string Level;

    Rigidbody2D rb;

    public void GotoLevel()
    {
        SceneManager.LoadScene(Level);
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene(menu);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject thing = other.gameObject;
        rb = other.GetComponent<Rigidbody2D>();
        if (thing.tag == "Player")
            GotoLevel();
        /*if(Level == "Level_2")
        {
            Debug.Log("HALP2");
            rb.transform.position = rb.transform.position + new Vector3(0, -40, 0);
        }
        if (Level == "Level_3")
        {
            Debug.Log("HALP3");
            rb.transform.position = rb.transform.position + new Vector3(60, 0, 0);
        }*/
    }
}
