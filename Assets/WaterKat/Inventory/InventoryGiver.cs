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

        public void GiveItemToPlayer(GameObject gameObject)
        {
            InventoryUI inventoryUI = gameObject.GetComponent<InventoryUI>();
            if ((inventoryUI != null) && (itemonPedestal)) 
            {
                inventoryUI.inventoryItems.Add(giftItem);
                itemonPedestal = false;
                displayItem.SetActive(false);
            }
            Debug.Log("Giving");
        }
    }
}

