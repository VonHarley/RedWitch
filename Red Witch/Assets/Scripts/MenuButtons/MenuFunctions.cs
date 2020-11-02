using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuFunctions : MonoBehaviour
{



    public void ToCity()
    {

        SceneManager.LoadScene("City");

    }

    public void ToMap()
    {

        SceneManager.LoadScene("Map");

    }


}
