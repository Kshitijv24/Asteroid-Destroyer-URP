using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelUpManager : MonoBehaviour
{
	public static PlayerLevelUpManager Instance { get; private set; }

    [SerializeField] int noOfEnemiesNeededToKillToLevelUp = 5;

    int killedEnemies;

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

    private void Update()
    {
        LevelUP();
    }

    public void IncrementKilledEnemies()
    {
        killedEnemies++;
    }

    public void LevelUP()
    {
        if(killedEnemies == noOfEnemiesNeededToKillToLevelUp)
        {
            killedEnemies = 0;
            GameManager.Instance.PauseGame();
            ScoreSystem.Instance.gameObject.SetActive(false);
            noOfEnemiesNeededToKillToLevelUp++;
        }
    }
}
