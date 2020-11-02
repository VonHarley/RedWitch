using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityData : MonoBehaviour
{


    public string[] shops_Aval;

    public int Silk, Wood, Iron, Stone, Gold, Food;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int FindPrice(string ItemName)
    {
        int cost = 0;
        if (ItemName == "Silk")
        {
            cost = Silk;
        }
        if (ItemName == "Wood")
        {
            cost = Wood;
        }
        if (ItemName == "Iron")
        {
            cost = Iron;
        }
        if (ItemName == "Stone")
        {
            cost = Stone;
        }
        if (ItemName == "Gold")
        {
            cost = Gold;
        }
        if (ItemName == "Food")
        {
            cost = Food;
        }
        return cost;
    }



}
