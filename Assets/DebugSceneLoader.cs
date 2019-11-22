using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugSceneLoader : MonoBehaviour
{
    public string[] Scenes = new string[]
    {
        "MENU",
        "BackAssStory",
        "TutorialScene",
        "Level_1",
        "Level_2",
        "Level_3",
        "BOSS",
        "Victory"
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKey("l") && Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene(Scenes[1]);
        }
        if (Input.GetKey("l") && Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene(Scenes[2]);
        }
        if (Input.GetKey("l") && Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene(Scenes[3]);
        }
        if (Input.GetKey("l") && Input.GetKeyDown("4"))
        {
            SceneManager.LoadScene(Scenes[4]);
        }
        if (Input.GetKey("l") && Input.GetKeyDown("5"))
        {
            SceneManager.LoadScene(Scenes[5]);
        }
        if (Input.GetKey("l") && Input.GetKeyDown("6"))
        {
            SceneManager.LoadScene(Scenes[6]);
        }
        if (Input.GetKey("l") && Input.GetKeyDown("7"))
        {
            SceneManager.LoadScene(Scenes[7]);
        }
        if (Input.GetKey("l") && Input.GetKeyDown("8"))
        {
            SceneManager.LoadScene(Scenes[0]);
        }
    }
}
