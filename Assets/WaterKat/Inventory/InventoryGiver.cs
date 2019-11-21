using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKat.Inventory
{
    public class InventoryGiver : MonoBehaviour
    {
        public InventoryItem giftItem;

        public GameObject displayItem;
        public bool itemonPedestal = true;

        public GameObject TargetPlayer = null;
        public void GiveItemToPlayer()
        {
            Debug.Log("Give TIem To PLayer");
            CharacterMovement2_5b inventoryUI = TargetPlayer.GetComponent<CharacterMovement2_5b>();
            if ((inventoryUI != null) && (itemonPedestal)) 
            {
                //   inventoryUI.inventoryItems.Add(giftItem);
                inventoryUI.hasEgg = true;
                itemonPedestal = false;
                displayItem.SetActive(false);
            }
            Debug.Log("Giving");
        }
    }
}

