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
            Debug.Log("There are more than one " + this.GetType() + " Instances", this);
            return;
        }
    }

    public bool IsPlayerLevelingUp() => isPlayerLevelingUp;

    public void PauseGameAndShowLevelUpPanel()
    {
        PlayerShootingPointManager.Instance.DeactivateAllShootingPoints();
        Time.timeScale = 0;
        levelUpCanvas.SetActive(true);
        ScoreSystem.Instance.GetScoreTextUI().enabled = false;
        PlayerHealth.Instance.GetPlayerHealthTextUI().enabled = false;
        isPlayerLevelingUp = true;
    }

    public void ResumeGameAndHideLevelUpPanel()
    {
        Invoke("WaitToShoot", 0.5f);
        Time.timeScale = 1;
        levelUpCanvas.SetActive(false);
        ScoreSystem.Instance.GetScoreTextUI().enabled = true;
        PlayerHealth.Instance.GetPlayerHealthTextUI().enabled = true;
        isPlayerLevelingUp = false;
    }

    private void WaitToShoot() => PlayerShootingPointManager.Instance.ActivateAllShootingPoints();
}
