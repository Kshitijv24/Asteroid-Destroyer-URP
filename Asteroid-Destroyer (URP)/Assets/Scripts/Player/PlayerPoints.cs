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

    public int GetPlayerPoints()
    {
        return playerPoints;
    }

    public void IncrementPlayerPoints()
    {
        playerPoints++;
    }
}
