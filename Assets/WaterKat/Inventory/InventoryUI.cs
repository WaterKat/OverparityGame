using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public CharacterMovement2_5b characterScript;
    public GameObject GunImage;
    public GameObject EggImage;
    public GameObject Ob_1Image;
    public GameObject Ob_2Image;

    private void Update()
    {
        GunImage.SetActive(characterScript.hasGun);
        EggImage.SetActive(characterScript.hasEgg);
    }
}
