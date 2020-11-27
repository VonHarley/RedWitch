using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shop : MonoBehaviour
{



    public int shopId;
    public int closingTime;
    public GameObject clock;

    // Start is called before the first frame update
    void Start()
    {
        clock = GameObject.Find("Clock");
        CheckTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckTime()
    {

        if (clock.GetComponent<TimeSystem>().timeSegments > closingTime)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        }

    }




    private void OnMouseOver()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            GameObject.Find("Data_Deliverable").GetComponent<DataManager>().NewShop(shopId);
            GameObject.Find("Data_Deliverable").GetComponent<DataManager>().StoreTime(1);
            SceneManager.LoadScene("Shop");
        }
    }





}
