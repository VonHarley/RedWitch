using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MapButtons : MonoBehaviour
{

    public GameObject[] pred;
    public bool occupied;
    public string[] travelItems;
    public int[] travelCost;
    public TMP_Text[] costDisplay;
    public GameObject player;

    public GameObject inv;
    public GameObject display;

    public string cityName;
    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Data_Deliverable").GetComponent<DataManager>().GetInventory();
        display = GameObject.Find("ResourceStock");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void DisplayCost()
    {

        for (int i = 0; i < travelItems.Length; i++)
        {

            costDisplay[i].text = "" + travelItems[i] + " x" + travelCost[i];


        }
    }

    void MovePlayer()
    {

        for (int i = 0; i < pred.Length; i++)
        {
            if (pred[i].GetComponent<MapButtons>().occupied)
            {
                pred[i].GetComponent<MapButtons>().occupied = false;
                occupied = true;
                player.transform.position = transform.position;
                TakeCost();
                display.GetComponent<ResourceDisplay>().DisplayAmounts();
                GameObject data = GameObject.Find("Data_Deliverable");
                data.GetComponent<DataManager>().NewPlace(cityName);
            }
        }



    }

    public void ForceMovePlayer()
    {
        occupied = true;
        player.transform.position = transform.position;
    //    display.GetComponent<ResourceDisplay>().DisplayAmounts();
  //      GameObject data = GameObject.Find("Data_Deliverable");
  //      data.GetComponent<DataManager>().NewPlace(cityName);
    }


    void TakeCost()
    {

        for (int i = 0; i < travelItems.Length; i++)
        {

            for (int j = 0; j < inv.GetComponent<PlayerInventory>().invNames.Length; j++)
            {

                if(travelItems[i] == inv.GetComponent<PlayerInventory>().invNames[j])
                {
                    inv.GetComponent<PlayerInventory>().invQuantity[j] = inv.GetComponent<PlayerInventory>().invQuantity[j] - travelCost[i];
                }


            }


        }




    }






    private void OnMouseEnter()
    {

        DisplayCost();



    }

    private void OnMouseExit()
    {
        
    }


    private void OnMouseDown()
    {
        MovePlayer();

    }




}
