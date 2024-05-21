using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelUpManager : MonoBehaviour
{
	public static PlayerLevelUpManager Instance { get; private set; }

    public int playerLevel = 1;
    public bool isLeveledUp;

    [HideInInspector] public int killedEnemies;
    [HideInInspector] public int noOfEnemiesNeededToKillToLevelUp;

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

    private void Start() => noOfEnemiesNeededToKillToLevelUp = PlayerPrefs.GetInt("PlayerInput");

    private void Update() => LevelUP();

    public void LevelUP()
    {
        if(killedEnemies >= noOfEnemiesNeededToKillToLevelUp 
            && PlayerHealth.Instance.GetPlayerHealth() > 0)
        {
            isLeveledUp = true;
            playerLevel++;
            killedEnemies = 0;
            GameManager.Instance.PauseGameAndShowLevelUpPanel();
            //noOfEnemiesNeededToKillToLevelUp++;
        }
    }
    public void IncrementKilledEnemiesAndPlayerPoints()
    {
        killedEnemies++;
        PlayerPoints.Instance.IncrementPlayerPointByOne();
    }
}
