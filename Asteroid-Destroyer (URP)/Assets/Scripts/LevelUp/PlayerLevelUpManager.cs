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

    public void IncrementKilledEnemiesAndPlayerPoints()
    {
        killedEnemies++;
        PlayerPoints.Instance.IncrementPlayerPoints();
    }

    public void LevelUP()
    {
        if(killedEnemies == noOfEnemiesNeededToKillToLevelUp 
            && PlayerHealth.Instance.GetPlayerHealth() > 0)
        {
            killedEnemies = 0;
            GameManager.Instance.PauseGameAndShowLevelUpPanel();
            //noOfEnemiesNeededToKillToLevelUp++;
        }
    }
}
