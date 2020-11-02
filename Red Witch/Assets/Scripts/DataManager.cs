using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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


}
