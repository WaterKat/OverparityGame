using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string menu;
    public string Level;

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
        if (thing.tag == "Player")
            GotoLevel();
    }
}
