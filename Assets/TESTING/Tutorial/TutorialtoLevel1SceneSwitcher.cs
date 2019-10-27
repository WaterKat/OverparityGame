using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialtoLevel1SceneSwitcher : MonoBehaviour
{
    public string menu;
    public string Level1;

    public void GotoLevel1()
    {
        SceneManager.LoadScene(Level1);
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene(menu);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject thing = other.gameObject;
        if (thing.tag == "Player")
            GotoLevel1();
    }
}
