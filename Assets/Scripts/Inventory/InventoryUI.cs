using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEditor.Progress;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventoryItem inventoryItemPrefab;
    [SerializeField] private RectTransform contentPanel;

    public List<InventoryItem> listInventoryItems = new List<InventoryItem>();
    
    public void InitializeInventroy(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            InventoryItem item = Instantiate(inventoryItemPrefab, Vector3.zero, Quaternion.identity);
            item.transform.SetParent(contentPanel);
            item.transform.localScale = Vector3.one;
            //item.buyButton.onClick.AddListener(()=>);
            listInventoryItems.Add(item);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
