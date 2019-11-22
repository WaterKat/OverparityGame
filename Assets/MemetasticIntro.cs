using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MemetasticIntro : MonoBehaviour
{
    public int currentPage = 1;
    public int maxPages = 11;

    public string TargetScene;
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            currentPage++;
            if (currentPage > maxPages)
            {
                SceneManager.LoadScene(TargetScene);
                return;
            }
        }

        for (int i = 1; i <= maxPages; i++)
        {
            transform.GetChild(i-1).gameObject.SetActive(false);
        }

        transform.GetChild(currentPage-1).gameObject.SetActive(true);
    }
}
