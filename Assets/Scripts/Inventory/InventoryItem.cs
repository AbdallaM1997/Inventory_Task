using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private GameObject priceTextHolder;
    [SerializeField]
    private TextMeshProUGUI priceText;
    [SerializeField]
    private GameObject purchasedText;

    [SerializeField]
    public Button buyButton;
    [SerializeField]
    public Button sellButton;

    private bool empty = true;

    public void Awake()
    {
        ResetData();
    }
    public void ResetData()
    {
        itemImage.gameObject.SetActive(false);
        buyButton.gameObject.SetActive(false);
        priceTextHolder.gameObject.SetActive(false);
        empty = true;
    }

    public void SetData(Sprite sprite, int price)
    {
        itemImage.gameObject.SetActive(true);
        buyButton.gameObject.SetActive(true);
        priceTextHolder.gameObject.SetActive(true);
        itemImage.sprite = sprite;
        priceText.text = price.ToString();
        empty = false;
    }
    public void BuyEffect()
    {
        buyButton.gameObject.SetActive(false);
        sellButton.gameObject.SetActive(true);
        priceTextHolder.SetActive(false);
        purchasedText.SetActive(true);
    }
    public void SellEffect()
    {
        buyButton.gameObject.SetActive(true);
        sellButton.gameObject.SetActive(false);
        priceTextHolder.SetActive(true);
        purchasedText.SetActive(false);
    }
}
