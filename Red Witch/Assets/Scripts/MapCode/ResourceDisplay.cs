using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResourceDisplay : MonoBehaviour
{
    public TMP_Text[] amounts;
    public GameObject data;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data_Deliverable");
        DisplayAmounts();
    }





    public void DisplayAmounts()
    {
        GameObject inv = data.GetComponent<DataManager>().GetInventory();
        for (int i = 0; i < amounts.Length; i++)
        {


            amounts[i].text = "" + inv.GetComponent<PlayerInventory>().invNames[i] + " x" + inv.GetComponent<PlayerInventory>().invQuantity[i];


        }


    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
