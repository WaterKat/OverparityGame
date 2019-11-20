using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventoryItem", menuName = "WaterKat/Inventory/InventoryItem", order = 50)]

public class InventoryItem : ScriptableObject
{
    public string displayName;
    public Sprite displaySprite;
    public GameObject itemPrefab;
}
