using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public GameObject GetInventory()
    {
        GameObject inv = null;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "PlayerStorage")
            {

                inv = transform.GetChild(i).gameObject;
                break;
            }
        }
        return inv;


    }

    public string AcquireCity(string cityName, int shopNum)
    {

        GameObject city = null;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if(transform.GetChild(i).name== cityName)
            {

                city = transform.GetChild(i).gameObject;
                break;
            }
        }
        string Shop = city.GetComponent<CityData>().shops_Aval[shopNum];
        return Shop;
    }

    public GameObject GetCity(string cityName)
    {


        GameObject city = null;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (transform.GetChild(i).name == cityName)
            {

                city = transform.GetChild(i).gameObject;
                break;
            }
        }
      
        return city;


    }


    public int CountShops(string cityName)
    {


        int num = 0;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (transform.GetChild(i).name == cityName)
            {

                num = transform.GetChild(i).transform.childCount;
                break;
            }
        }

        return num;
    }

    public GameObject ShopInventory(string cityName, int shopInv)
    {
        GameObject city = null;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (transform.GetChild(i).name == cityName)
            {

                city = transform.GetChild(i).gameObject;
                break;
            }
        }
        return city.transform.GetChild(shopInv).gameObject; 
    }


    public void NewPlace(string cityName)
    {
        for (int i = 0; i < transform.childCount; i++)
        {

            if(transform.GetChild(i).name == "PlayerPlacement")
            {
                transform.GetChild(i).gameObject.GetComponent<PlayerPlacement>().cityName = cityName;
            }

        }



    }

    public void NewShop(int num)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "PlayerPlacement")
            {
                transform.GetChild(i).gameObject.GetComponent<PlayerPlacement>().recentShopId = num;
            }
        }
    }

    public int RetrieveShopID()
    {
        int num = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "PlayerPlacement")
            {
                num = transform.GetChild(i).gameObject.GetComponent<PlayerPlacement>().recentShopId;
            }
        }
        return num;
    }

    public GameObject CurrentCity()
    {
        GameObject temp = null;
        for (int i = 0; i < transform.childCount; i++)
        {

            if (transform.GetChild(i).name == "PlayerPlacement")
            {
                temp = transform.GetChild(i).gameObject;
            }

        }
        return temp;
    }

    public void StoreTime(int time)
    {

        for (int i = 0; i < transform.childCount; i++)
        {

            if (transform.GetChild(i).name == "PlayerPlacement")
            {
                transform.GetChild(i).gameObject.GetComponent<PlayerPlacement>().savedTime = transform.GetChild(i).gameObject.GetComponent<PlayerPlacement>().savedTime + time;
            }

        }


    }

    public void ResetTime()
    {

        for (int i = 0; i < transform.childCount; i++)
        {

            if (transform.GetChild(i).name == "PlayerPlacement")
            {
                transform.GetChild(i).gameObject.GetComponent<PlayerPlacement>().savedTime = 0;
            }

        }
    }

    public int RetrieveTime()
    {
        int temp = 0;
        for (int i = 0; i < transform.childCount; i++)
        {

            if (transform.GetChild(i).name == "PlayerPlacement")
            {
                temp = transform.GetChild(i).gameObject.GetComponent<PlayerPlacement>().savedTime;
            }

        }
        return temp;
    }

    public int DoomStageGet()
    {

        int temp = 0;
        for (int i = 0; i < transform.childCount; i++)
        {

            if (transform.GetChild(i).name == "PlayerPlacement")
            {
                temp = transform.GetChild(i).gameObject.GetComponent<PlayerPlacement>().stateOfDoom;
            }

        }
        return temp;
    }

    public void DoomStageAdd(int add)
    {


        for (int i = 0; i < transform.childCount; i++)
        {

            if (transform.GetChild(i).name == "PlayerPlacement")
            {
                transform.GetChild(i).gameObject.GetComponent<PlayerPlacement>().stateOfDoom = transform.GetChild(i).gameObject.GetComponent<PlayerPlacement>().stateOfDoom + add;
            }

        }

    }

    public void MapInfoDeposit(string cityName, string[] destinations)
    {


        for (int i = 0; i < transform.childCount; i++)
        {

            if (transform.GetChild(i).name == "MapInfo")
            {
                if (transform.GetChild(i).gameObject.GetComponent<MapInfoManager>().mapCollected == false)
                {
                    transform.GetChild(i).gameObject.GetComponent<MapInfoManager>().StoreMapPoint(cityName, destinations);
                }
            }

        }

    }

    public void MapInfoStop()
    {


        for (int i = 0; i < transform.childCount; i++)
        {

            if (transform.GetChild(i).name == "MapInfo")
            {
                transform.GetChild(i).gameObject.GetComponent<MapInfoManager>().mapCollected = true;
            }

        }

    }

    public GameObject[] GetNextCities(string cityName)
    {
        GameObject info = null;
        for (int i = 0; i < transform.childCount; i++)
        {

            if (transform.GetChild(i).name == "MapInfo")
            {
                info = transform.GetChild(i).gameObject;
            }

        }

        GameObject[] next = new GameObject[0];

        for (int i = 0; i < info.transform.childCount; i++)
        {

            for (int j = 0; j < info.transform.GetChild(i).transform.childCount; j++)
            {
                if (info.transform.GetChild(i).transform.GetChild(j).name ==cityName)
                {
                    GameObject[] temp = new GameObject[next.Length +1];
                    for (int c = 0; c < next.Length; c++)
                    {
                        temp[c] = next[c];
                    }
                    temp[next.Length] = info.transform.GetChild(i).gameObject;
                    next = temp;
                }
            }

        }

        return next;
    }

}
