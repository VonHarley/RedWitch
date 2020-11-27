using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_BuySell : MonoBehaviour
{

    public bool dir;
    public int tier;
    public string itemName;
    public int itemAmount;
    public GameObject Manager;

    private void Start()
    {
        itemName = Manager.GetComponent<ShopManager>().invNames[tier];
        itemAmount = Manager.GetComponent<ShopManager>().invQuantity[tier];
    }

    public void ChooseItem()
    {
        int curAmount = Manager.GetComponent<ShopManager>().invQuantity[tier];
        if (curAmount > 0 && dir == false)
        {
            Manager.GetComponent<ShopManager>().TradeShopItem(dir, itemName);
        }
        if (curAmount < itemAmount && dir)
        {
            Manager.GetComponent<ShopManager>().TradeShopItem(dir, itemName);
        }
    }

    public void UpdateItemData()
    {

        itemName = Manager.GetComponent<ShopManager>().invNames[tier];
        itemAmount = Manager.GetComponent<ShopManager>().invQuantity[tier];

    }

}
