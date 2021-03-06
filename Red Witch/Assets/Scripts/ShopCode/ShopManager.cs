﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopManager : MonoBehaviour
{
    //ShopKeep Stock
    public string[] invNames;
    public int[] invQuantity;
    public int[] invPrice;

    //Player Stock
    private GameObject playerInv;
    public string[] playerInvNames;
    public int[] playerInvQuantity;
    public int[] playerInvPrice;

    //Shop Information
    public int shopID;
    public string cityName;

    //ShopKeepInventoryButtons
    public TMP_Text[] shopInvDisplay;
    public GameObject[] shopInvButtonsIncrease;
    public GameObject[] shopInvButtonsDecrease;


    //PlayerInventoryButtons
    public TMP_Text[] playerInvDisplay;
    public GameObject[] playerInvButtonsIncrease;
    public GameObject[] playerInvButtonsDecrease;


    //Scale
    public GameObject scale;


    // Start is called before the first frame update
    void Start()
    {
        shopID = GameObject.Find("Data_Deliverable").GetComponent<DataManager>().RetrieveShopID();
        FindCity();
        SpawnInventory();
        playerInv = GameObject.Find("PlayerStorage");
        playerInvNames = playerInv.GetComponent<PlayerInventory>().invNames;
        playerInvQuantity = playerInv.GetComponent<PlayerInventory>().invQuantity;
        AquireCatolog();
        DisplayInv();
        DisplayPlayerInv();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FindCity()
    {

        GameObject data = GameObject.Find("Data_Deliverable");
        for (int i = 0; i < data.transform.childCount; i++)
        {
            if (data.transform.GetChild(i).name == "PlayerPlacement")
            {
                cityName = data.transform.GetChild(i).gameObject.GetComponent<PlayerPlacement>().cityName;
            }
        }
    }

        void SpawnInventory()
    {
        GameObject data = GameObject.Find("Data_Deliverable");
        GameObject shopInv = data.GetComponent<DataManager>().ShopInventory(cityName,shopID);
        invNames = shopInv.GetComponent<ShopData>().invNames;
        invQuantity = shopInv.GetComponent<ShopData>().invQuantity;
     //   invPrice = shopInv.GetComponent<ShopData>().invPrice;


    }


    void AquireCatolog()
    {
        GameObject data = GameObject.Find("Data_Deliverable");

        invPrice = new int[invNames.Length];
        for (int i = 0; i < invNames.Length; i++)
        {

            invPrice[i] = data.GetComponent<DataManager>().GetCity(cityName).GetComponent<CityData>().FindPrice(invNames[i]);


        }
        playerInvPrice = new int[playerInvNames.Length];
        for (int i = 0; i < playerInvNames.Length; i++)
        {

            playerInvPrice[i] = data.GetComponent<DataManager>().GetCity(cityName).GetComponent<CityData>().FindPrice(playerInvNames[i]);


        }





    }




    void DisplayInv()
    {

        for (int i = 0; i < invNames.Length; i++)
        {
            shopInvButtonsIncrease[i].SetActive(true);
            shopInvButtonsDecrease[i].SetActive(true);
            shopInvDisplay[i].text = "" + invNames[i] + " " + invQuantity[i];


        }



    }


    void DisplayPlayerInv()
    {

        for (int i = 0; i < playerInvNames.Length; i++)
        {
            playerInvButtonsIncrease[i].SetActive(true);
            playerInvButtonsDecrease[i].SetActive(true);
            playerInvDisplay[i].text = "" + playerInvNames[i] + " " + playerInvQuantity[i];


        }



    }





    public void TradeShopItem(bool dir, string itemName)
    {
        int invSlot = 0;
        int value;

        if (dir)
        {
            value = 1;
        }
        else
        {
            value = -1;
        }


        for (int i = 0; i < invNames.Length; i++)
        {
            if (invNames[i] == itemName)
            {
                break;
            }
            else
            {
                invSlot++;
            }
        }

        invQuantity[invSlot] = invQuantity[invSlot] + value;
        scale.GetComponent<BallanceScale>().ShopScale(dir, itemName, invPrice[invSlot], false);
        DisplayInv();
    }



    public void TradePlayerItem(bool dir, string itemName)
    {
        int invSlot = 0;
        int value;

        if (dir)
        {
            value = 1;
        }
        else
        {
            value = -1;
        }


        for (int i = 0; i < playerInvNames.Length; i++)
        {
            if (playerInvNames[i] == itemName)
            {
                break;
            }
            else
            {
                invSlot++;
            }
        }

        playerInvQuantity[invSlot] = playerInvQuantity[invSlot] + value;
        scale.GetComponent<BallanceScale>().ShopScale(!dir, itemName, playerInvPrice[invSlot], true);
        DisplayPlayerInv();
    }





    public void ConfirmBarter()
    {
        int ballanceValue = scale.GetComponent<BallanceScale>().storedValue;
     //   bool isBallanced;
     //Shop Scale
     //Player Scale
        if (ballanceValue > -1)
        {
            string[] itemList = scale.GetComponent<BallanceScale>().shopScale;
            for (int i = 0; i < itemList.Length; i++)
            {
                if (itemList[i] != "")
                {
                    int invSlot = 0;

                    for (int j = 0; j < playerInvNames.Length; j++)
                    {
                        if (playerInvNames[j] == itemList[i])
                        {
                            break;
                        }
                        else
                        {
                            invSlot++;
                        }
                    }

                    playerInvQuantity[invSlot] = playerInvQuantity[invSlot] + 1;
                }
            }

            itemList = scale.GetComponent<BallanceScale>().playersScale;
            for (int i = 0; i < itemList.Length; i++)
            {
                if (itemList[i] != "")
                {
                    int invSlot = 0;

                    for (int j = 0; j < invNames.Length; j++)
                    {
                        if (invNames[j] == itemList[i])
                        {
                            break;
                        }
                        else
                        {
                            invSlot++;
                        }
                    }

                    invQuantity[invSlot] = invQuantity[invSlot] + 1;
                }
            }



            scale.GetComponent<BallanceScale>().ClearBallance();
            DisplayInv();
            DisplayPlayerInv();

            GameObject[] buttonsShop = GameObject.FindGameObjectsWithTag("ShopButtons_S");
            for (int i = 0; i < buttonsShop.Length; i++)
            {
                buttonsShop[i].GetComponent<Shop_BuySell>().UpdateItemData();
            }
            GameObject[] buttonsPlayer = GameObject.FindGameObjectsWithTag("ShopButtons_P");
            for (int i = 0; i < buttonsShop.Length; i++)
            {
                buttonsPlayer[i].GetComponent<Player_BuySell>().UpdateItemData();
            }


            if (ballanceValue > 4)
            {
                GameObject.Find("Patronage").GetComponent<PatronManager>().AddPatronage(3);
            }else
                if (ballanceValue > 2)
            {
                GameObject.Find("Patronage").GetComponent<PatronManager>().AddPatronage(2);
            }
            else
            {
                GameObject.Find("Patronage").GetComponent<PatronManager>().AddPatronage(1);
            }
        }
        

    }




}
