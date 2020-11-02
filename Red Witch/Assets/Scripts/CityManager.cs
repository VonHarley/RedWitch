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
        SpawnCity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCity()
    {

        GameObject data = GameObject.Find("Data_Deliverable");
        for (int i = 0; i < 5; i++)
        {
            SpawnShop(data.GetComponent<DataManager>().AcquireCity(cityName, i), i);
        }




    }

    void SpawnShop(string shopType, int slot)
    {
        GameObject nodes = transform.GetChild(0).gameObject;

        if (shopType == "Open")
        {

           GameObject shop =  Instantiate(shopImage);
            shop.transform.position = nodes.transform.GetChild(slot).gameObject.transform.position;

        }

    }




}
