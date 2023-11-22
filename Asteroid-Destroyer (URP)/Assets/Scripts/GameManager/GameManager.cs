using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance {  get; private set; }

    [SerializeField] GameObject levelUpCanvas;

    bool isPlayerLevelingUp;

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

    public void PauseGameAndShowLevelUpPanel()
    {
        Time.timeScale = 0;
        levelUpCanvas.SetActive(true);
        ScoreSystem.Instance.GetScoreTextUI().enabled = false;
        PlayerHealth.Instance.GetPlayerHealthTextUI().enabled = false;
        isPlayerLevelingUp = true;
    }

    public void ResumeGameAndHideLevelUpPanel()
    {
        Time.timeScale = 1;
        levelUpCanvas.SetActive(false);
        ScoreSystem.Instance.GetScoreTextUI().enabled = true;
        PlayerHealth.Instance.GetPlayerHealthTextUI().enabled = true;
        isPlayerLevelingUp = false;
    }

    public bool IsPlayerLevelingUp() => isPlayerLevelingUp;
}
