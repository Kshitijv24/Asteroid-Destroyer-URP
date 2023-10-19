using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] GameObject pauseButton;

	public void ResumeGame()
	{
        Time.timeScale = 1;
		pauseButton.SetActive(true);
		gameObject.SetActive(false);
    }
}
