using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public GameObject[] cityLocations;
    public GameObject data;





    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data_Deliverable");
        string cityName = data.GetComponent<DataManager>().CurrentCity().GetComponent<PlayerPlacement>().cityName;
        for (int i = 0; i < cityLocations.Length; i++)
        {

            if(cityLocations[i].GetComponent<MapButtons>().cityName== cityName)
            {
                cityLocations[i].GetComponent<MapButtons>().ForceMovePlayer();
            }
            else
            {
                cityLocations[i].GetComponent<MapButtons>().occupied = false;
            }


        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
