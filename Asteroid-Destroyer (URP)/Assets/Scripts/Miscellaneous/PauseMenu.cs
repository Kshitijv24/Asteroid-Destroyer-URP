using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] GameObject pauseButton;

	public void ResumeGame()
	{
        Time.timeScale = 1;
		pauseButton.SetActive(true);
		gameObject.SetActive(false);
    }

	public void ExitToMainMenu()
	{
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
	}

	public void ExitGame()
	{
        Time.timeScale = 1;
        Application.Quit();
	}
}
