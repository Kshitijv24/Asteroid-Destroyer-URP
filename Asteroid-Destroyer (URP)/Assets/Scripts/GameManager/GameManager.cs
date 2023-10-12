using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance {  get; private set; }

    [SerializeField] GameObject levelUpCanvas;

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

    public GameObject GetLevelUpCanvas() => levelUpCanvas;

    public void PauseGame()
    {
        Time.timeScale = 0;
        levelUpCanvas.SetActive(true);
        ScoreSystem.Instance.GetScoreTextUI().enabled = false;
        PlayerHealth.Instance.GetPlayerHealthTextUI().enabled = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        levelUpCanvas.SetActive(false);
        ScoreSystem.Instance.GetScoreTextUI().enabled = true;
        PlayerHealth.Instance.GetPlayerHealthTextUI().enabled = true;
    }
}
