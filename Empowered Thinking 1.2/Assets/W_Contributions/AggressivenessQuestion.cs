using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class AggressivenessQuestion : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {

    }

    public void mustWin()
    {
        SceneManager.LoadScene("Extroversion");
    }

    public void walkAway()
    {
        SceneManager.LoadScene("Extroversion");
    }

}
