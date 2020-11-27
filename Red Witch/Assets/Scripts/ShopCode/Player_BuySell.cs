using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BuySell : MonoBehaviour
{
    public bool dir;
    public int tier;
    public string itemName;
    public int itemAmount;
    public GameObject Manager;

    private void Start()
    {
        itemName = Manager.GetComponent<ShopManager>().playerInvNames[tier];
        itemAmount = Manager.GetComponent<ShopManager>().playerInvQuantity[tier];
    }

    public void ChooseItem()
    {
        int curAmount = Manager.GetComponent<ShopManager>().playerInvQuantity[tier];
        if (curAmount > 0 && dir == false)
        {
            Manager.GetComponent<ShopManager>().TradePlayerItem(dir, itemName);
        }
        if (curAmount < itemAmount && dir)
        {
            Manager.GetComponent<ShopManager>().TradePlayerItem(dir, itemName);
        }
        
    }

    public void UpdateItemData()
    {

        itemName = Manager.GetComponent<ShopManager>().playerInvNames[tier];
        itemAmount = Manager.GetComponent<ShopManager>().playerInvQuantity[tier];

    }

}
