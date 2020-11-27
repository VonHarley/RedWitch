using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButtonManager : MonoBehaviour
{

    GameObject data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data_Deliverable");
        SetupMapInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SetupMapInfo()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            string main = transform.GetChild(i).gameObject.GetComponent<MapButtons>().cityName;
            string[] sub = new string[transform.GetChild(i).gameObject.GetComponent<MapButtons>().pred.Length];

            for (int j = 0; j< sub.Length; j++)
            {

                sub[j] = transform.GetChild(i).gameObject.GetComponent<MapButtons>().pred[j].gameObject.GetComponent<MapButtons>().cityName;


            }

            data.GetComponent<DataManager>().MapInfoDeposit(main,sub);
        }

        data.GetComponent<DataManager>().MapInfoStop();

    }



}
