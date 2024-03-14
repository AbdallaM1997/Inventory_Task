using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]
public class InventoryDataItem : ScriptableObject
{
    [field: SerializeField]
    public int idItem;
    [field: SerializeField]
    public string displayName;
    [field: SerializeField]
    public Sprite icon;
    [field: SerializeField]
    public int price;
}
