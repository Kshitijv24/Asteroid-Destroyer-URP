using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public static PauseButton Instance { get; private set; }

    [SerializeField] GameObject pauseMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PauseGame()
	{
        if (GameManager.Instance.IsPlayerLevelingUp()) return;

        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
