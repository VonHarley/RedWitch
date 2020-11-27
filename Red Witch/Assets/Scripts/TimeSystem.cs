using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimeSystem : MonoBehaviour
{
    public int timeSegments;
    public TMP_Text display;
    public int maxTime;
    // Start is called before the first frame update


    void Start()
    {
        GetTime();
        DisplayTime();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    
    void GetTime()
    {
        timeSegments = GameObject.Find("Data_Deliverable").GetComponent<DataManager>().RetrieveTime();
    }

    void DisplayTime()
    {
        string starting = "Time: ";
        display.text = starting + timeSegments + "/" + maxTime;

    }



}
