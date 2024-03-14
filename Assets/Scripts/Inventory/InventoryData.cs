using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Inventory System/Inventory Type")]
public class InventoryData : ScriptableObject
{
    public List<InventoryDataItem> inventoryDataItem;

}
