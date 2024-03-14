using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEditor.Progress;

public class InventoryController : Singleton<InventoryController>
{
    [Header("Data")]
    [SerializeField] public InventoryData shopkeeper1InventoryData;
    [SerializeField] public InventoryData shopkeeper2InventoryData;
    [Header("InventoryUI")]
    [SerializeField] private InventoryUI shopkeeper1Inventory;
    [SerializeField] private InventoryUI shopKeeper2Inventory;
    [SerializeField] private GameObject bankPanel;
    [SerializeField] private int inventorySize;
    [Header("UI References")]
    [SerializeField] private GameObject buttonsHolder;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        shopkeeper1Inventory.InitializeInventroy(inventorySize);
        shopKeeper2Inventory.InitializeInventroy(inventorySize);
        for (int i = 0; i < shopkeeper1InventoryData.inventoryDataItem.Count; i++)
        {
            shopkeeper1Inventory.listInventoryItems[i].SetData(shopkeeper1InventoryData.inventoryDataItem[i].icon, shopkeeper1InventoryData.inventoryDataItem[i].price);
            int savedID = shopkeeper1InventoryData.inventoryDataItem[i].idItem;
            shopkeeper1Inventory.listInventoryItems[i].buyButton.onClick.AddListener(delegate
            {
                Player.Instance.SellItemShopkeeper(savedID, shopkeeper1InventoryData, shopkeeper1Inventory);
                shopkeeper1Inventory.listInventoryItems[savedID].BuyEffect();
            });
            shopkeeper1Inventory.listInventoryItems[i].sellButton.onClick.AddListener(delegate
            {
                Player.Instance.BuyItemShopkeeper(savedID, shopkeeper1InventoryData, shopkeeper1Inventory);
                shopkeeper1Inventory.listInventoryItems[savedID].SellEffect();
            });
        }
        for (int i = 0; i < shopkeeper2InventoryData.inventoryDataItem.Count; i++)
        {
            shopKeeper2Inventory.listInventoryItems[i].SetData(shopkeeper2InventoryData.inventoryDataItem[i].icon, shopkeeper2InventoryData.inventoryDataItem[i].price);
            int savedID = shopkeeper2InventoryData.inventoryDataItem[i].idItem;
            shopKeeper2Inventory.listInventoryItems[i].buyButton.onClick.AddListener(delegate
            {
                Player.Instance.SellItemShopkeeper(savedID, shopkeeper2InventoryData, shopKeeper2Inventory);
            });
            shopKeeper2Inventory.listInventoryItems[i].sellButton.onClick.AddListener(delegate
            {
                Player.Instance.BuyItemShopkeeper(savedID, shopkeeper2InventoryData, shopKeeper2Inventory);
            });
        }
    }

    public void ShowShopKeeper1Inventory()
    {
        if (shopkeeper1Inventory.isActiveAndEnabled == false) 
        {
            shopkeeper1Inventory.Show();
            buttonsHolder.SetActive(false);
        }
        else
        {
            shopkeeper1Inventory.Hide();
            buttonsHolder.SetActive(true);
        }
    }
    public void ShowShopKeeper2Inventory()
    {
        if (shopKeeper2Inventory.isActiveAndEnabled == false)
        {

            shopKeeper2Inventory.Show();
            buttonsHolder.SetActive(false);
        }
        else
        {
            shopKeeper2Inventory.Hide();
            buttonsHolder.SetActive(true);
        }
    }
    public void ShowBank()
    {
        if (bankPanel.activeInHierarchy == false)
        {
            bankPanel.SetActive(true);
            buttonsHolder.SetActive(false);
        }
        else
        {
            bankPanel.SetActive(false);
            buttonsHolder.SetActive(true);
        }
    }
}
