using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SleepQuestion : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void noSleep()
    {
        SceneManager.LoadScene("Diet");
    }

    public void someSleep()
    {
        SceneManager.LoadScene("Diet");
    }

    public void moreSleep()
    {
        SceneManager.LoadScene("Diet");
    }

    public void lotsOfSleep()
    {
        SceneManager.LoadScene("Diet");
    }


}
