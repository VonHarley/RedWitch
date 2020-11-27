using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDoom : MonoBehaviour
{

    public int doomStage;

    public GameObject doomWall;

    public GameObject[] doomStages;
    // Start is called before the first frame update
    void Start()
    {
        doomStage = GameObject.Find("Data_Deliverable").GetComponent<DataManager>().DoomStageGet();
        moveDoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void moveDoom()
    {

        doomWall.transform.position = doomStages[doomStage].transform.position;
        


    }



}
