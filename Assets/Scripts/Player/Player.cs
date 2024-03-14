using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : Singleton<Player>
{
    [Header("References")]
    [SerializeField]
    private TMP_Text coinsText;    
    [SerializeField]
    private TMP_Text bankAccountText;    
    [SerializeField]
    private TMP_InputField bankInputfield;
    [Header("Proprietes")]
    [SerializeField]
    private int coins = 1000;
    [SerializeField]
    private int bankAccount = 3000;

    protected override void Awake()
    {
        base.Awake();
        coinsText.text = coins.ToString();
        bankAccountText.text = bankAccount.ToString();
    }

    // Method to modify coin balance
    public void ModifyCoins(int amount)
    {
        coins += amount;
        coinsText.text = coins.ToString();
    }

    // Method to modify bank account balance
    public void ModifyBankAccount(int amount)
    {
        bankAccount += amount;
        bankAccountText.text = bankAccount.ToString();
    }

    // Method to increase bank account by 10%
    public void Sleep()
    {
        bankAccount += Mathf.FloorToInt(bankAccount * 0.1f);
        bankAccountText.text = bankAccount.ToString();
    }
    public void SellItemShopkeeper(int itemIndex , InventoryData shopkeeperInventoryData, InventoryUI shopKeeperInventory)
    {
        print(itemIndex);
        if (coins >= shopkeeperInventoryData.inventoryDataItem[itemIndex].price)
        {
            ModifyCoins(-shopkeeperInventoryData.inventoryDataItem[itemIndex].price);
            shopKeeperInventory.listInventoryItems[itemIndex].BuyEffect();

            // Add item to player's inventory (not implemented here)
            Debug.Log("Item purchased: " + shopkeeperInventoryData.inventoryDataItem[itemIndex].name);
        }
        else
        {
            Debug.Log("Not enough coins.");
        }
    }
    public void BuyItemShopkeeper(int itemIndex, InventoryData shopkeeperInventoryData, InventoryUI shopKeeperInventory)
    {
        if (coins >= shopkeeperInventoryData.inventoryDataItem[itemIndex].price)
        {
            ModifyCoins(+shopkeeperInventoryData.inventoryDataItem[itemIndex].price / 2);
            shopKeeperInventory.listInventoryItems[itemIndex].SellEffect();

            // Add item to player's inventory (not implemented here)
            Debug.Log("Item purchased: " + shopkeeperInventoryData.inventoryDataItem[itemIndex].name);
        }
        else
        {
            Debug.Log("Not enough coins.");
        }
    }

    public void Deposit()
    {
        int amount = int.Parse(bankInputfield.text.ToString());
        if (coins >= amount)
        {
            ModifyCoins(-amount);
            ModifyBankAccount(amount);
        }
    }

    public void Withdraw()
    {
        int amount = int.Parse(bankInputfield.text.ToString());
        if (bankAccount >= amount)
        {
            ModifyBankAccount(-amount);
            ModifyCoins(amount);
        }
    }
}
