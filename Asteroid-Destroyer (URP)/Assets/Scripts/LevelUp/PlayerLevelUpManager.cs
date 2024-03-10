using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelUpManager : MonoBehaviour
{
	public static PlayerLevelUpManager Instance { get; private set; }

    public int noOfEnemiesNeededToKillToLevelUp = 5;
    public int playerLevel = 1;

    [HideInInspector] public int killedEnemies;

    private void Awake()
    {
        if (Instance == null)
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

    private void Update() => LevelUP();

    public void LevelUP()
    {
        if(killedEnemies >= noOfEnemiesNeededToKillToLevelUp 
            && PlayerHealth.Instance.GetPlayerHealth() > 0)
        {
            playerLevel++;
            killedEnemies = 0;
            GameManager.Instance.PauseGameAndShowLevelUpPanel();
            noOfEnemiesNeededToKillToLevelUp++;
        }
    }
    public void IncrementKilledEnemiesAndPlayerPoints()
    {
        killedEnemies++;
        PlayerPoints.Instance.IncrementPlayerPointByOne();
    }
}
