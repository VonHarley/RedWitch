using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shop : MonoBehaviour
{






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseOver()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            SceneManager.LoadScene("Shop");
        }
    }

    void DataDeliverable()
    {

        GameObject data = new GameObject();
        data.name = "Shop_Data";




    }



}
