using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuFunctions : MonoBehaviour
{
    public bool doomIncrease;
    public bool TimeReset;

    public void ToCity()
    {
        if (doomIncrease)
        {
            GameObject.Find("Data_Deliverable").GetComponent<DataManager>().DoomStageAdd(1);
        }
        if (TimeReset)
        {
            GameObject.Find("Data_Deliverable").GetComponent<DataManager>().ResetTime();
        }
        SceneManager.LoadScene("City");

    }

    public void ToMap()
    {

        SceneManager.LoadScene("Map");

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
