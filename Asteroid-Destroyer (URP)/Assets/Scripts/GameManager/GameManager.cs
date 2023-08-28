using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance {  get; private set; }

    [SerializeField] GameObject levelUpCanvas;

    bool isPaused;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetLevelUpCanvas()
    {
        return levelUpCanvas;
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    public void PauseGame()
    {
        //isPaused = true;
        Time.timeScale = 0;
        levelUpCanvas.SetActive(true);
        ScoreSystem.Instance.GetScoreTextUI().enabled = false;
        PlayerHealth.Instance.GetPlayerHealthTextUI().enabled = false;
        //Debug.Log("Game is paused");
    }

    public void ResumeGame()
    {
        //isPaused = false;
        Time.timeScale = 1;
        levelUpCanvas.SetActive(false);
        ScoreSystem.Instance.GetScoreTextUI().enabled = true;
        PlayerHealth.Instance.GetPlayerHealthTextUI().enabled = true;
        //Debug.Log("Game is unpaused");
    }
}