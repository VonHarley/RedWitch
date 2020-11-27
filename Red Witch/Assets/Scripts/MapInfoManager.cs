using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfoManager : MonoBehaviour
{

    public bool mapCollected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StoreMapPoint(string cityName,string[] destinations)
    {

        GameObject main = new GameObject();
        main.name = cityName;
        main.transform.parent = transform;

        for (int i = 0; i < destinations.Length; i++)
        {

            GameObject sub = new GameObject();
            sub.name = destinations[i];
            sub.transform.parent = main.transform;

        }

    }



}
