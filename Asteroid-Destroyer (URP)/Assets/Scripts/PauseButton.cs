using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void PauseGame()
	{
        if (GameManager.Instance.IsPlayerLevelingUp()) return;

        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
