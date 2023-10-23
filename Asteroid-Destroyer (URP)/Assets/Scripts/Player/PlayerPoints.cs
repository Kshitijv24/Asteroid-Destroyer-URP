using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public static PlayerPoints Instance { get; private set; }

    int playerPoints = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerPoints = GetPlayerPoints();
    }

    public int GetPlayerPoints()
    {
        return PlayerPrefs.GetInt("playerPoints", playerPoints);
    }

    public void IncrementPlayerPoints()
    {
        playerPoints++;
        PlayerPrefs.SetInt("playerPoints", playerPoints);
    }
}
