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

    public GameObject GetLevelUpCanvas() => levelUpCanvas;

    public bool IsPlayerLevelingUp() => isPlayerLevelingUp;

    public void PauseGameAndShowLevelUpPanel()
    {
        //foreach (PlayerShooting playerShooting in FindObjectsOfType(typeof(PlayerShooting)))
        //{
        //    playerShooting.enabled = false;
        //}

        //FindObjectOfType<PlayerShooting>().enabled = false;
        Time.timeScale = 0;
        levelUpCanvas.SetActive(true);
        ScoreSystem.Instance.GetScoreTextUI().enabled = false;
        PlayerHealth.Instance.GetPlayerHealthTextUI().enabled = false;
        isPlayerLevelingUp = true;
    }

    public void ResumeGameAndHideLevelUpPanel()
    {
        //foreach (PlayerShooting playerShooting in FindObjectsOfType(typeof(PlayerShooting)))
        //{
        //    playerShooting.enabled = true;
        //}

        //FindObjectOfType<PlayerShooting>().enabled = true;
        Time.timeScale = 1;
        levelUpCanvas.SetActive(false);
        ScoreSystem.Instance.GetScoreTextUI().enabled = true;
        PlayerHealth.Instance.GetPlayerHealthTextUI().enabled = true;
        isPlayerLevelingUp = false;
    }
}
