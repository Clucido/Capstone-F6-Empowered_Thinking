using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                resume();
            }

            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void openMenu()
    {
        Debug.Log("Opening Menu...");
        SceneManager.LoadScene("Menu");
    }

    public void quitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }


}
