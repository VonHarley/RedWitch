using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BallanceScale : MonoBehaviour
{

    public GameObject neutral;
    public GameObject leftLeaning;
    public GameObject rightLeaning;

    public int storedValue;

    public string[] playersScale = new string[10];
    public string[] shopScale = new string[10];
    public TMP_Text[] playerStock = new TMP_Text[10];
    public TMP_Text[] shopStock = new TMP_Text[10];


    public void ShopScale(bool dir, string itemName, int itemPrice, bool player)
    {
        int value = 0;
        if (dir)
        {
            value = 1;
            if (player)
            {
                for (int i = 0; i < playersScale.Length; i++)
                {
                    if (playersScale[i] == "")
                    {
                        playersScale[i] = itemName;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < shopScale.Length; i++)
                {
                    if (shopScale[i] == itemName)
                    {
                        shopScale[i] = "";
                        break;
                    }
                }
            }

        }
        else
        {
            value = -1;
            if (player)
            {
                for (int i = 0; i < playersScale.Length; i++)
                {
                    if (playersScale[i] == itemName)
                    {
                        playersScale[i] = "";
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < shopScale.Length; i++)
                {
                    if (shopScale[i] == "")
                    {
                        shopScale[i] = itemName;
                        break;
                    }
                }
            }

        }



        storedValue = storedValue + (itemPrice * value);
        CheckScale();

    }






    public void CheckScale()
    {
        neutral.SetActive(false);
        leftLeaning.SetActive(false);
        rightLeaning.SetActive(false);
        if (storedValue == 0)
        {
            neutral.SetActive(true);
        }
        if (storedValue > 0)
        {
            rightLeaning.SetActive(true);
        }
        if(storedValue < 0)
        {
            leftLeaning.SetActive(true);
        }
        DisplayStock();
    }


    void DisplayStock()
    {

        for (int i = 0; i < 6; i++)
        {
            playerStock[i].text = "";
            shopStock[i].text = "";



        }

        string item = " ";
        int displaySlot = 0;
        string[] tempStock = new string[10];
        for (int i = 0; i < tempStock.Length; i++)
        {
            tempStock[i] = playersScale[i];
        }
        
        while (item != "")
        {
            int stock = 0;
            item = "";
            for (int i = 0; i < tempStock.Length; i++)
            {
                if (item == "" && tempStock[i] != "")
                {
                    item = tempStock[i];
                    tempStock[i] = "";
                    stock++;
                }
                else if (tempStock[i] == item && tempStock[i] != "")
                {
                    stock++;
                    tempStock[i] = "";
                }
            }
            if (item != "")
            {
                playerStock[displaySlot].text = "" + item + " x" + stock;
                displaySlot++;
            }
        }

        item = " ";
        displaySlot = 0;
        for (int i = 0; i < tempStock.Length; i++)
        {
            tempStock[i] = shopScale[i];
        }
        while (item != "")
        {
            int stock = 0;
            item = "";
            for (int i = 0; i < tempStock.Length; i++)
            {
                if (item == "" && tempStock[i] != "")
                {
                    item = tempStock[i];
                    tempStock[i] = "";
                    stock++;
                }
                else if (tempStock[i] == item && tempStock[i] != "")
                {
                    stock++;
                    tempStock[i] = "";
                }
            }
            if (item != "")
            {
                shopStock[displaySlot].text = "" + item + " x" + stock;
                displaySlot++;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
