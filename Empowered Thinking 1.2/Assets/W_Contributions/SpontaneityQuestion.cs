using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SpontaneityQuestion : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {

    }

    public void no()
    {
        SceneManager.LoadScene("Aggressiveness");
    }

    public void yes()
    {
        SceneManager.LoadScene("Aggressiveness");
    }
}