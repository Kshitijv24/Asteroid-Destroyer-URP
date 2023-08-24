using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelUpManager : MonoBehaviour
{
	public static PlayerLevelUpManager Instance { get; private set; }

    [SerializeField] GameObject LevelUpCanvas;

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
        if(killedEnemies == 10)
        {
            GameManager.Instance.PauseGame();
            LevelUpCanvas.SetActive(true);
            ScoreSystem.Instance.gameObject.SetActive(false);
        }
    }
}
