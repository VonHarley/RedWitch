using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PatronManager : MonoBehaviour
{

    public int patronage;
    public GameObject bar;
    public float full;

    public GameObject mapData;

    public string cityName;
    public TMP_Text givenHint;
    // Start is called before the first frame update
    void Start()
    {
        givenHint.text = "";
        cityName = GameObject.Find("ShopCreator").GetComponent<ShopManager>().cityName;
        Adjust();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddPatronage(int value)
    {

        patronage = patronage + value;
        
        if (patronage >= 5)
        {
            patronage = patronage - 5;
            GiveInfo();

        }
        Adjust();
    }


    void Adjust()
    {


        bar.transform.localScale = new Vector3(bar.transform.localScale.x,(.2f*patronage), bar.transform.localScale.z);


    }



    // an empty with childs of each connecting area
    void GiveInfo()
    {
        GameObject[] places = GameObject.Find("Data_Deliverable").GetComponent<DataManager>().GetNextCities(cityName);
        GameObject place = places[Random.Range(0, places.Length)];

        GameObject city = null;

        for (int i = 0; i < GameObject.Find("Data_Deliverable").transform.childCount; i++)
        {
            if(GameObject.Find("Data_Deliverable").transform.GetChild(i).name == place.name)
            {
                city = GameObject.Find("Data_Deliverable").transform.GetChild(i).gameObject;
                break;
            }
        }

        int itemSlot = Random.Range(0, 6);
        string itemName = "";
        int itemValue = 0;

        switch (itemSlot) {

            case 0:
                itemName = "Silk";
                itemValue = city.GetComponent<CityData>().Silk;
                break;

            case 1:
                itemName = "Wood";
                itemValue = city.GetComponent<CityData>().Wood;
                break;

            case 2:
                itemName = "Iron";
                itemValue = city.GetComponent<CityData>().Iron;
                break;

            case 3:
                itemName = "Stone";
                itemValue = city.GetComponent<CityData>().Stone;
                break;

            case 4:
                itemName = "Gold";
                itemValue = city.GetComponent<CityData>().Gold;
                break;

            case 5:
                itemName = "Food";
                itemValue = city.GetComponent<CityData>().Food;
                break;
        }

        if (itemValue < 3)
        {
            givenHint.text = city.name + " buy's " + itemName + " for cheap";
        }else
        if (itemValue < 6)
        {
            givenHint.text = city.name + " buy's " + itemName + " for an average price";
        }else
        if (itemValue < 8)
        {
            givenHint.text = city.name + " buy's " + itemName + " for a lot";
        }



    }

}
