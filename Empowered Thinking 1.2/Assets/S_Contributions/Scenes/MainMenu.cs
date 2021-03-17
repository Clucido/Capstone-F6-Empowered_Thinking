using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene(string Choose_Scene)
    {
        SceneManager.LoadScene(Choose_Scene);
		Debug.Log("BUTTON BOI CLICKED");
    }
	
	public void QuitGame() 
	{
		Debug.Log("Quit.");
		Application.Quit();
		Debug.Log("GAME GONNA QUIT");
	}

}
