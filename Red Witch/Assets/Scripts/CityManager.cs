using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{


    public GameObject shopImage;

    public string cityName;

    // Start is called before the first frame update
    void Start()
    {
        FindCity();
        SpawnCity();
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


    void SpawnCity()
    {

        GameObject data = GameObject.Find("Data_Deliverable");
        for (int i = 0; i < data.GetComponent<DataManager>().CountShops(cityName); i++)
        {
            SpawnShop(data.GetComponent<DataManager>().AcquireCity(cityName, i), i);
        }




    }

    void SpawnShop(string shopType, int slot)
    {
        GameObject nodes = transform.GetChild(0).gameObject;
        GameObject data = GameObject.Find("Data_Deliverable");
        if (shopType == "Open")
        {

           GameObject shop =  Instantiate(shopImage);
            shop.transform.position = nodes.transform.GetChild(slot).gameObject.transform.position;
            shop.GetComponent<Shop>().shopId = slot;
            GameObject city = data.GetComponent<DataManager>().GetCity(cityName);

                    shop.GetComponent<Shop>().closingTime = city.transform.GetChild(slot).gameObject.GetComponent<ShopData>().ShopClosure;

        }

    }




}
